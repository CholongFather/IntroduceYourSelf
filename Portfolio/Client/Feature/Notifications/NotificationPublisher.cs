using MediatR;

using Portfolio.Shared.Notifications;

namespace Portfolio.Client.Notifications;

public class NotificationPublisher : INotificationPublisher
{
	private readonly ILogger<NotificationPublisher> _logger;
	private readonly IPublisher _mediator;

	public NotificationPublisher(ILogger<NotificationPublisher> logger, IPublisher mediator) =>
		(_logger, _mediator) = (logger, mediator);

	public Task PublishAsync(INotificationMessage notification)
	{
		_logger.LogInformation("Publishing Notification : {notification}", notification.GetType().Name);

		return _mediator.Publish(CreateNotificationWrapper(notification));
	}

	private INotification CreateNotificationWrapper(INotificationMessage notification) =>
		(INotification)Activator.CreateInstance(
			typeof(NotificationWrapper<>).MakeGenericType(notification.GetType()), notification)!;
}