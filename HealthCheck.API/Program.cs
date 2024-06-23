using Hangfire;
using HealthCheck.API.Extensions;
using HealthCheck.Business;
using HealthCheck.Business.Services;
using HealthCheck.Entity.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString); 
});

builder.Services.AddHangfire(config =>
{
    config.UseSqlServerStorage(connectionString);
});
builder.Services.AddHangfireServer();
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.RegisterDbContext(builder.Configuration);
builder.Services.RegisterMappers();
builder.Services.RegisterServices();

var app = builder.Build();
app.UseHangfireDashboard();
ServiceProviderFactory.ServiceProvider = app.Services;
RecurringJob.AddOrUpdate("health-check-job", () => HealthCheckService.Check(), Cron.MinuteInterval(5));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
