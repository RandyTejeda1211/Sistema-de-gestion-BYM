using Microsoft.EntityFrameworkCore;
using SGBYM.Application.Interfaces;
using SGBYM.Application.Interfaces.security;
using SGBYM.Application.Services;
using SGBYM.Domain.Interfaces;
using SGBYM.Infrastructure.Data;
using SGBYM.Infrastructure.Repositories;
using SGBYM.Infrastructure.Repository;
using SGBYM.Infrastructure.Security;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IPassHasher, BcryptPassHasher>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IClienteService, ClientService>();
builder.Services.AddScoped<IAdminRepository, AdministratorRepository> ();
builder.Services.AddScoped<IAdminService, AdminService> ();
builder.Services.AddScoped<IServiceProvidedRepository, ServiceProvidedRepository>();
builder.Services.AddScoped<IServiceProvided, ServiceProvidedService>();
builder.Services.AddScoped<ICiteRepository, CiteRepository>();
builder.Services.AddScoped<ICiteService, CiteService>();
builder.Services.AddScoped<BillService>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginServices>();
builder.Services.AddScoped<JwtService>();






//configuracion de cors para que la api solo funcione desde la url seleccionada
builder.Services.AddCors(options =>
{
    options.AddPolicy("Permitir frontend local", policy =>
    {
        policy
            
            .WithOrigins("http://127.0.0.1:3002")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors("Permitir frontend local");

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
