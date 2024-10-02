using System;
using System.Collections.Generic;
using System.Text;
using Eentities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

namespace DdataAccess
{
    public class InventaryContext : DbContext
    {

        public DbSet<ProductEntity> Products { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<InputOutputEntity> InOuts { get; set; }

        public DbSet<WhereHouseEntity> Wherehouses { get; set; }

        public DbSet<StorageEntity> Storages { get; set; }

        public InventaryContext(DbContextOptions<InventaryContext> options)
        : base(options)
        {
        }

        // Constructor sin parámetros
        public InventaryContext() : base(new DbContextOptions<InventaryContext>())
        {
        
        }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {


                var DB_SERVER = "junction.proxy.rlwy.net";
                var DB_PORT = "38582";
                var DB_DATABASE = "railway";
                var DB_USER = "root";
                var DB_PASSWORD = "qTDaklKYQLEaNQIkUsoGlkSMAiDRzIIT";

                if (string.IsNullOrEmpty(DB_SERVER) || string.IsNullOrEmpty(DB_DATABASE) || string.IsNullOrEmpty(DB_USER) || string.IsNullOrEmpty(DB_PASSWORD))
                {
                    throw new InvalidOperationException("Faltan variables de Entorno para la configuración de la BD.");
                }


                options.UseMySql(
                    $"Server={DB_SERVER};Port={DB_PORT};Database={DB_DATABASE};User={DB_USER};Password={DB_PASSWORD};",
                    new MySqlServerVersion(new Version(8, 0, 27)),
                    mySqlOptions => mySqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 5,
                        maxRetryDelay: TimeSpan.FromSeconds(10),
                        errorNumbersToAdd: null
                    )
                );
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CategoryEntity>().HasData(
                new CategoryEntity { CategoryId = "ASH", CategoryName = "Aseo Hogar"},
                new CategoryEntity { CategoryId = "ASP", CategoryName = "Aseo Personal"},
                new CategoryEntity { CategoryId = "HGR", CategoryName = "Hogar"},
                new CategoryEntity { CategoryId = "PRF", CategoryName = "Perfumería"},
                new CategoryEntity { CategoryId = "SLD", CategoryName = "Salud"},
                new CategoryEntity { CategoryId = "VDJ", CategoryName = "Video Juegos" }
                );

            modelBuilder.Entity<ProductEntity>().HasData(
                new ProductEntity { ProductId = "ASJ-98745", ProductName = "Crema para manos marca Tersa", ProductDescription = "ddwd", TotalQuantity = 100, CategoryId = "PRF" },
                new ProductEntity { ProductId = "RPT-5465879", ProductName = "Pastillas para la garganta LESUS", ProductDescription = "sadad", TotalQuantity = 200, CategoryId = "SLD" }
                );

            modelBuilder.Entity<WhereHouseEntity>().HasData(
                new WhereHouseEntity { WhereHouseId = Guid.NewGuid().ToString(), WhereHouseName = "Bodega Central", WhereHouseAddress = "Calle 8 con 23" },
                new WhereHouseEntity { WhereHouseId = Guid.NewGuid().ToString(), WhereHouseName = "Bodega Norte", WhereHouseAddress = "Calle norte con occidente"}
                );



        }

    }

}

//protected override void OnConfiguring(DbContextOptionsBuilder options)
//{
//    if (!options.IsConfigured)
//    {
//        options.UseMySql("Server=;Database=;User=root;Password=",
//            new MySqlServerVersion(new Version(8, 0, 27))),
//          mySqlOptions => mySqlOptions.EnableRetryOnFailure(
//    maxRetryCount: 5,
//    maxRetryDelay: TimeSpan.FromSeconds(10),
//    errorNumbersToAdd: null)
//);

//    }
//}

