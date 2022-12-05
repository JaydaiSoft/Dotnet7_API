global using Microsoft.EntityFrameworkCore;
using Dotnet7_API.Data;
using Dotnet7_API.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

var CorsPolicy = "CorsPolicy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: CorsPolicy,
        builder => builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
        //.AllowCredentials()
        //.WithOrigins("http://localhost:61671")
        .AllowAnyOrigin());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("productservicedb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseCors(CorsPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();

