namespace IntroduceMySelfAPI;

public class Startup
{
	public IConfiguration Configuration { get; }

	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

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

		services.AddAuthentication("Bearer")
				.AddJwtBearer("Bearer", options =>
				{
					options.Authority = "http://localhost:8080";
					options.RequireHttpsMetadata = false;
					options.TokenValidationParameters.NameClaimType = JwtClaimTypes.Name;
					options.Audience = "introduce";
				});
	}

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
