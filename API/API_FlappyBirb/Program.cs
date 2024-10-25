using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_FlappyBirb.Data;
using API_FlappyBirb.Models;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<API_FlappyBirbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("API_FlappyBirbContext") ?? throw new InvalidOperationException("Connection string 'API_FlappyBirbContext' not found."));
    options.UseLazyLoadingProxies();
});

builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<API_FlappyBirbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("Allow all", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Allow all");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
