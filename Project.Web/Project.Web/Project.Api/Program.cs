using InstantAPIs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project.Data.Context;
using System.Configuration;
using WEB.StartupExtentions;
using log4net;
using log4net.Config;
using System.Reflection;
using Project.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Configure log4net
var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
XmlConfigurator.Configure(logRepository, new FileInfo("config/log4net.config"));
// End Configure log4net


// Add configuration to the app
//builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddControllers();

// Add services to the container.
builder.Services.ConfiguringRepositories();
builder.Services.ConfiguringServices();
builder.Services.ConfiguringGlobalServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapInstantAPIs<testcontext>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<Middleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
