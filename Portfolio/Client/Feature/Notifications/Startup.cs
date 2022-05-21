using MediatR;
using MediatR.Courier;
using MediatR.Courier.DependencyInjection;

using Portfolio.Shared.Notifications;

namespace Portfolio.Client.Notifications;

internal static class Startup
{
	public static IServiceCollection AddNotifications(this IServiceCollection services)
	{
		System.Reflection.Assembly[]? assemblies = AppDomain.CurrentDomain.GetAssemblies();

		services.AddMediatR(assemblies)
			.AddCourier(assemblies)
			.AddTransient<INotificationPublisher, NotificationPublisher>();

		foreach (Type? eventType in assemblies.SelectMany(a => a.GetTypes()).Where(t => t.GetInterfaces().Any(i => i == typeof(INotificationMessage))))
		{
			services.AddSingleton(
				typeof(INotificationHandler<>).MakeGenericType(
					typeof(NotificationWrapper<>).MakeGenericType(eventType)),
				serviceProvider => serviceProvider.GetRequiredService(typeof(MediatRCourier)));
		}

		return services;
	}
}