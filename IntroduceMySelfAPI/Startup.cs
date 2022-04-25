namespace IntroduceMySelfAPI;

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
