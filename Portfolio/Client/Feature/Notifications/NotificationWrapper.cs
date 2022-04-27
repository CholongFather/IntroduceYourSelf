using MediatR;

using Portfolio.Shared.Notifications;

namespace Portfolio.Client.Notifications;

public class NotificationWrapper<TNotificationMessage> : INotification
	where TNotificationMessage : INotificationMessage
{
	public NotificationWrapper(TNotificationMessage notification) => Notification = notification;

	public TNotificationMessage Notification { get; }
}