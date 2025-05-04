using Microsoft.EntityFrameworkCore;
using System;
using Warehouse.Data.Db;
using Warehouse.Repositories;
using Warehouse.Repositories.Impl;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WarehouseDbContext>(opt => opt.UseInMemoryDatabase("InMen"));
builder.Services.AddScoped<IAddressRepository, AddressRepositoryImpl>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepositoryImpl>();
builder.Services.AddScoped<IProductRepository, ProductRepositoryImpl>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepositoryImpl>();


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
