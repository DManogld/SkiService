using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.OpenApi.Models;
using Serilog;
using SkiService.Midelware;
using SkiService.Models;
using SkiService.Services;

var builder = WebApplication.CreateBuilder(args);
// Configure DI for application services diese Initializiert ein Objekt
//builder.Services.AddScoped<IRegistrationServices, RegistrationJsonService>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<RegistrationContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("C1")));

builder.Services.AddScoped<IRegistrationServices, RegistrationDbServices>();
builder.Services.AddScoped<IStatusServices, StatusDbServices>();
builder.Services.AddScoped<IPriorityServices, PriorityDBServices>();

// Loger 
var loggerFromSettings = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration)
	.Enrich.FromLogContext()
	.CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(loggerFromSettings);


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


/*TODO :
 * Restliche Methode in Services Fertig stellen--> DONE
 * Das Programm so ergänzen das man eine Liste von Services angezeigt wird welche Sortiert ist nach Piority--> DONE
 * Try Catch implementieren mit Logger
 * API Key einfügen / Custom Midelwar --> DONE
 * Logger einfügen --> Not sure
 * Ergänzen so das wen beim eintragen von neue Client ein Atribut fehlt ein NotFound.
 * Connection string den Passwort verschlüsseln --> DONE
 * DB Mit neuen Server Connectiction Nicht über Windowos (SQL) --> Done
 * Program Kommentiere
 */
