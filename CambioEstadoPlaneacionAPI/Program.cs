using Datos.Clases.DAL;
using Datos.Clases.DO;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Negocio.Clases.BL;

var builder = WebApplication.CreateBuilder(args);

// Configurar Inyeccion de Dependencias
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddScoped<IPlaneacionRepository, PlaneacionRepository>();
builder.Services.AddScoped<IPlaneacionService, PlaneacionService>();

// Add services to the container.

builder.Services.AddRazorPages();
// Configuración del controlador y Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.MapControllers();
app.Run();
