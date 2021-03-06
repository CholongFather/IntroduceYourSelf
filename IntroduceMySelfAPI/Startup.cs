using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;
using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Configuration;


using StackExchange.Redis.Extensions.Newtonsoft;
using IdentityModel;
using Serilog;

namespace IntroduceMySelfAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddControllers();
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "IntroduceMySelfAPI", Version = "v1" });
			});

			services.AddStackExchangeRedisExtensions<NewtonsoftSerializer>((options) =>
			{
				return Configuration.GetSection("Redis").Get<RedisConfiguration>();
			});

			services.AddCors(o => o.AddPolicy("AllowAll", builder =>
			{
				builder.AllowAnyOrigin()
					   .AllowAnyMethod()
					   .AllowAnyHeader();
			}));

			//인증용
			services.AddAuthentication("Bearer")
					.AddJwtBearer("Bearer", options => 
					{
						options.Authority = "http://localhost:8080";
						options.RequireHttpsMetadata = false;
						options.TokenValidationParameters.NameClaimType = JwtClaimTypes.Name;
						options.Audience = "introduce";
					});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IntroduceMySelfAPI v1"));
			}

			app.UseSerilogRequestLogging();

			app.UseRouting();

			app.UseCors("AllowAll");

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
