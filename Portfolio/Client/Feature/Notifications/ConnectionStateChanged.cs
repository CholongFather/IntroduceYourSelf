using Portfolio.Shared.Notifications;

namespace Portfolio.Client.Notifications;

public record ConnectionStateChanged(ConnectionState State, string? Message) : INotificationMessage;