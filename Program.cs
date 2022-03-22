using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProductsService.DAL.Context;
using ProductsService.DAL.Repositories;
using ProductsService.DAL.Repositories.Interfaces;
using ProductsService.Models;
using ProductsService.Services;
using ProductsService.Services.Clients;
using ProductsService.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen(options =>
{
    var xmlFilename = "api.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

//Database
services.AddDbContext<ApplicationDbContext>(optionsAction => optionsAction
    .UseSqlServer(builder.Configuration.GetConnectionString("Default")));

//Mapper
services.AddAutoMapper(Assembly.GetEntryAssembly());

services.AddScoped(typeof(IRepository<>), typeof(DbRepository<>));

services.AddScoped<IProductsService, ProductService>();

//Client
var brandsAPI = builder.Configuration.GetValue<string>("BrandsAPI");
services.AddHttpClient<BrandsClient>(client => client.BaseAddress = new(brandsAPI));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(config =>
{
    config.AllowAnyHeader();
    config.AllowAnyMethod();
    config.AllowCredentials();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
