using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyFirstBackend.Api.Common;
using MyFirstBackend.Models;
using MyFirstBackend.Repositories;
using MyFirstBackend.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

IConfiguration configuration = builder.Configuration;

builder.Services.AddDbContextPool<ApplicationDbContext>(e =>
{
    e.UseMySql(
        configuration.GetConnectionString("LocalConnection"),
        ServerVersion.AutoDetect(configuration.GetConnectionString("LocalConnection")),
        e => e.MigrationsAssembly("MyFirstBackend.Api")
        );
});

JwtSettings.Configure(builder);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<IStudent, StudentRepository>();
builder.Services.AddScoped<IBook, BookRepository>();
builder.Services.AddScoped<IAllotment, AllotmentRepository>();
builder.Services.AddScoped<IApplicationUser, ApplicationUserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors(e => e.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
    app.MapOpenApi();
    app.MapScalarApiReference("/", e =>
    {
        e.Theme = ScalarTheme.DeepSpace;
        e.WithTitle("arshdon`");
    });
}


app.UseHttpsRedirection();



app.UseAuthentication();

app.UseAuthorization();



app.MapControllers();

app.Run();