using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.API.Context;
using Product.API.Products;
using Product.API.Profile;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProductContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ProductsConnectionString"), sqlServerOptionsAction:
    sqlOptions => { sqlOptions.EnableRetryOnFailure(); }));
builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddMediatR(typeof(CreateCommand).Assembly);
var app = builder.Build();

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