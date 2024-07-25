using ApiTrabajador.BLL.Services.Contracts;
using ApiTrabajador.BLL.Services.Entities;
using ApiTrabajador.DAL.Context;
using ApiTrabajador.DAL.Repositories.Contracts;
using ApiTrabajador.DAL.Repositories.Entities;
using ApiTrabajador.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DbapitrabajadorContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("conexion"));
});

// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repostories
builder.Services.AddScoped<IGenericRepository<Cargo>, CargoRepository>();
builder.Services.AddScoped<IGenericRepository<Trabajador>, TrabajadorRepository>();

//Services
builder.Services.AddScoped<ICargoService, CargoService>();
builder.Services.AddScoped<ITrabajadorService, TrabajadorService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.Run();
