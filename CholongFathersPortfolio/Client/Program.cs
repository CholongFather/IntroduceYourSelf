using Blazorise;
using Blazorise.Material;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CholongFathersPortfolio.Client
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebAssemblyHostBuilder.CreateDefault(args);
			builder.Services
			  .AddBlazorise(options =>
			  {
				  options.ChangeTextOnKeyPress = true;
			  })
			  .AddMaterialProviders()
			  .AddFontAwesomeIcons();

			builder.Services.AddSingleton(new HttpClient
			{
				BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
			});

			builder.RootComponents.Add<App>("#app");

			await builder.Build().RunAsync();
		}
	}
}
