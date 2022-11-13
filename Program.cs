using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using SkiService.Models;
using SkiService.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// DB verbindung herstellen
builder.Services.AddDbContext<RegistrationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("C1")));


// Configure DI for application services diese Initializiert ein Objekt
builder.Services.AddScoped<IRegistrationServices, RegistrationDbServices>();
builder.Services.AddScoped<IStatusServices, StatusDbServices>();
builder.Services.AddScoped<IPriorityServices, PriorityDBServices>();
builder.Services.AddScoped<IMitarbeiterDbService, MitarbeiterService>();

// Seri Logger mit appsettings.json Konfiguration
var loggerFromSettings = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration)
	.Enrich.FromLogContext()
	.CreateLogger();

//Logger
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(loggerFromSettings);

// Swagger/OpenAPI konfigurieren
builder.Services.AddSwaggerGen(options =>
{
	options.SwaggerDoc("v1", new OpenApiInfo
	{
		Version = "v1",
		Title = "Ski-Service API",
		Description = "Ski Service Anmeldung",
		TermsOfService = new Uri("https://www.ipso.ch/ibz"),
		Contact = new OpenApiContact
		{ 
			Name = "INFEFZ",
			Url = new Uri("https://www.ipso.ch/ibz")
		},
		License = new OpenApiLicense
		{ 
			Name = "IPSO",
			Url = new Uri("https://www.ipso.ch/ibz")
		}
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseMiddleware<ApiKeyMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
