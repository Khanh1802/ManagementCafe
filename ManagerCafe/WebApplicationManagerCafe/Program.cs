using ManagerCafe.Data.Data;
using ManagerCafe.Profiles;
using ManagerCafe.Repositories;
using ManagerCafe.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(option => option
.AddDefaultPolicy(x => x
.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod()));
//C1:
//var connectionString = builder.Configuration.GetConnectionString("ManagerCafe");
//builder.Services.AddDbContext<ManagerCafeDbContext>(options =>
//{
//    options.UseSqlServer(connectionString);
//});

//C2:
builder.Services.AddDbContext<ManagerCafeDbContext>(opts =>
opts.UseSqlServer(builder.Configuration.GetConnectionString("ManagerCafe")));
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddAutoMapper(typeof(ProductProfile));
builder.Services.AddMemoryCache();

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
