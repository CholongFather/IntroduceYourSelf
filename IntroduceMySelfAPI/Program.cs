using Serilog.Events;

namespace IntroduceMySelfAPI;

public class Program
{
	public static void Main(string[] args)
	{
		Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
			.Enrich.FromLogContext()
			.WriteTo.Console()
			.CreateLogger();

		try
		{
			Log.Information("Starting Introduce API Server");
			CreateHostBuilder(args).Build().Run();
		}
		catch (Exception ex)
		{
			Log.Fatal(ex, "Host terminated unexpectedly");
		}
		finally
		{
			Log.CloseAndFlush();
		}
	}

	public static IHostBuilder CreateHostBuilder(string[] args) =>
		Host.CreateDefaultBuilder(args)
			.UseSerilog()
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseKestrel();
				webBuilder.UseStartup<Startup>();
				webBuilder.ConfigureKestrel(serverOptions =>
				{
					serverOptions.ListenAnyIP(8080);
				});
			});
}
