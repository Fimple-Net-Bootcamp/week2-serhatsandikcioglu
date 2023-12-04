using Microsoft.EntityFrameworkCore;
using SpaceWeatherForecast.Data.DataBase;
using SpaceWeatherForecast.Data.Interfaces;
using SpaceWeatherForecast.Data.Repositories;
using SpaceWeatherForecast.Service.Interfaces;
using SpaceWeatherForecast.Service.Mapper;
using SpaceWeatherForecast.Service.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IPlanetService, PlanetService>();
builder.Services.AddScoped<IPlanetRepository, PlanetRepository>();
builder.Services.AddScoped<ISatelliteService, SatelliteService>();
builder.Services.AddScoped<ISatelliteRepository, SatelliteRepository>();
builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection"), Action => {
        Action.MigrationsAssembly("SpaceWeatherForecast.Data");
    });
});
var app = builder.Build();

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
