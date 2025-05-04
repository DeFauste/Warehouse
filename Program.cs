using Microsoft.EntityFrameworkCore;
using System;
using Warehouse.Data.Db;
using Warehouse.Repositories;
using Warehouse.Repositories.Impl;
using Warehouse.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Add DB
builder.Services.AddDbContext<WarehouseDbContext>(opt => opt.UseInMemoryDatabase("InMen"));
builder.Services.AddScoped<IAddressRepository, AddressRepositoryImpl>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepositoryImpl>();
builder.Services.AddScoped<IProductRepository, ProductRepositoryImpl>();
builder.Services.AddScoped<ISupplierRepository, SupplierRepositoryImpl>();
//Add Services
builder.Services.AddScoped<AddressService, AddressService>();
builder.Services.AddScoped<CategoryService, CategoryService>();
builder.Services.AddScoped<ProductService, ProductService>();
builder.Services.AddScoped<SupplierService, SupplierService>();

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
