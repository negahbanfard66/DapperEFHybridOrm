using DapperEfhybridSample.Application.Services;
using DapperEfHybridSample.Core.Interfaces;
using DapperEfHybridSample.Infrastructure.Data;
using DapperEfHybridSample.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Add EF Core
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Dapper
builder.Services.AddScoped<IDbConnection>(sp =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new SqlConnection(connectionString);
});


builder.Services.AddKeyedTransient<IProductRepository, EfCoreProductRepository>("EfCore");
builder.Services.AddKeyedTransient<IProductRepository, DapperProductRepository>("Dapper");
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddSwaggerGen();

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
