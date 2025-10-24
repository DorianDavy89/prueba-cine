using Infraestructura.Persistencias;
using Infraestructura.Repository;
using Infraestructura.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContext
builder.Services.AddDbContext<CineDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IRepositorioPelicula, RepositorioPelicula>();
builder.Services.AddScoped<IPeliculaService, ServicioPelicula>();
builder.Services.AddScoped<IRepositorioPeliculaSalaCine, RepositorioPeliculaSala>();
builder.Services.AddScoped<IPeliculaSalaCineService, ServicioPeliculaSalaCine>();
builder.Services.AddScoped<IRepositorioSalaCine, RepositorioSalaCine>();
builder.Services.AddScoped<ISalaCineService, ServicioSalaCine>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
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

app.UseCors("AllowAngular");

app.UseAuthorization();

app.MapControllers();

app.Run();
