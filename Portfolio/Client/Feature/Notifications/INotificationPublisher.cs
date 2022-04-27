using Portfolio.Shared.Notifications;

namespace Portfolio.Client.Notifications;

public interface INotificationPublisher
{
	Task PublishAsync(INotificationMessage notification);
}