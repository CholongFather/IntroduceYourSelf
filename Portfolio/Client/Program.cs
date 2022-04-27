var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddMudServices();

builder.Services.AddScoped<IClientPreferenceManager, ClientPreferenceManager>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var host = builder.Build();

var storageService = host.Services.GetRequiredService<IClientPreferenceManager>();
if (storageService != null)
{
	CultureInfo culture;
	culture = new CultureInfo("ko-KR");
	CultureInfo.DefaultThreadCurrentCulture = culture;
	CultureInfo.DefaultThreadCurrentUICulture = culture;
}

await host.RunAsync();