using DemoProvinciasCrud.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// Swagger (para probar CRUD desde el navegador)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Servir web estática desde wwwroot
app.UseDefaultFiles(); // busca index.html
app.UseStaticFiles();

app.MapControllers();

app.Run();
