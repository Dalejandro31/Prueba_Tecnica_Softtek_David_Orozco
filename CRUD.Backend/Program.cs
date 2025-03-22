using System;
using System.Text.Json.Serialization;
using CRUD.Backend.Data;
using CRUD.Backend.Interfaces;
using CRUD.Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Configura la base de datos con SQL Server usando la cadena de conexi�n "LocalConnection"
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("LocalConnection"));
});

// Inyecta las implementaciones de servicios usando el patr�n Scoped (una instancia por request HTTP)
builder.Services.AddScoped<IAutorService, AutorService>();
builder.Services.AddScoped<ILibroService, LibroService>();

// Configura los controladores para evitar referencias c�clicas al serializar objetos
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

// Configura la pol�tica de CORS para permitir peticiones desde el frontend en Blazor
builder.Services.AddCors(options => { options.AddPolicy("AllowAll", policy => {
    policy.WithOrigins("https://localhost:7079")
        .AllowAnyHeader()
        .AllowCredentials()
        .AllowAnyMethod();
});
});

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Habilita CORS con la pol�tica definida
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
