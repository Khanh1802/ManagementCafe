﻿using ManagerCafe.Data.Data;
using ManagerCafe.Data.Models;
using ManagerCafe.Profiles;
using ManagerCafe.Repositories;
using ManagerCafe.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WinFormsAppManagerCafe.Inventories;
using WinFormsAppManagerCafe.Products;
using WinFormsAppManagerCafe.WareHouses;

namespace WinFormsAppManagerCafe
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build();
            ServiceProvider = host.Services; // Buoc 2: Khoi tao host.Services
            Application.Run(ServiceProvider.GetRequiredService<HomePage>()); // Form1 => là project tạo từ Winform Init
        }

        public static IServiceProvider ServiceProvider { get; private set; }

        static IHostBuilder CreateHostBuilder() // Buoc 1: Khoi tao Iterface
        {
            return Host.CreateDefaultBuilder()
           .ConfigureServices((context, services) =>
           {
               services.AddDbContext<ManagerCafeDbContext>(opts =>
               {
                   var config = context.Configuration.GetConnectionString("ManagerCafe");
                   opts.UseMySql(config, MySqlServerVersion.LatestSupportedServerVersion);
               });
               services.AddTransient<IProductRepository, ProductRepository>();
               services.AddTransient<IProductService, ProductService>();
               services.AddTransient<IWareHouseRepository, WareHouseRepository>();
               services.AddTransient<IWareHouseService, WareHouseService>();
               services.AddTransient<IInventoryRepository,IInventoryRepository>();
               services.AddTransient<IInventoryService, InventoryService>();
               services.AddTransient<HomePage>();
               services.AddTransient<FormProduct>();
               services.AddTransient<FormAddProduct>();
               services.AddTransient<FormWareHouse>();
               services.AddTransient<FormAddWareHouse>();
               services.AddTransient<FormInventory>();
               services.AddAutoMapper(typeof(ProductProfile));
               services.AddAutoMapper(typeof(WareHouseProfile));
               services.AddAutoMapper(typeof(InventoryProfile));
           });
        }
    }
}