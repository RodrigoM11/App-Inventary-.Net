﻿// <auto-generated />
using System;
using DdataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DdataAccess.Migrations
{
    [DbContext(typeof(InventaryContext))]
    [Migration("20240918201240_FirstMigration")]
    partial class FirstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Eentities.CategoryEntity", b =>
                {
                    b.Property<string>("CategoryId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = "ASH",
                            CategoryName = "Aseo Hogar"
                        },
                        new
                        {
                            CategoryId = "ASP",
                            CategoryName = "Aseo Personal"
                        },
                        new
                        {
                            CategoryId = "HGR",
                            CategoryName = "Hogar"
                        },
                        new
                        {
                            CategoryId = "PRF",
                            CategoryName = "Perfumería"
                        },
                        new
                        {
                            CategoryId = "SLD",
                            CategoryName = "Salud"
                        },
                        new
                        {
                            CategoryId = "VDJ",
                            CategoryName = "Video Juegos"
                        });
                });

            modelBuilder.Entity("Eentities.InputOutputEntity", b =>
                {
                    b.Property<string>("InOutId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("InOutDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsInput")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StorageId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("InOutId");

                    b.HasIndex("StorageId");

                    b.ToTable("InOuts");
                });

            modelBuilder.Entity("Eentities.ProductEntity", b =>
                {
                    b.Property<string>("ProductId")
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("CategoryId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ProductDescription")
                        .IsRequired()
                        .HasMaxLength(600)
                        .HasColumnType("varchar(600)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TotalQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = "ASJ-98745",
                            CategoryId = "PRF",
                            ProductDescription = "ddwd",
                            ProductName = "Crema para manos marca Tersa",
                            TotalQuantity = 100
                        },
                        new
                        {
                            ProductId = "RPT-5465879",
                            CategoryId = "SLD",
                            ProductDescription = "sadad",
                            ProductName = "Pastillas para la garganta LESUS",
                            TotalQuantity = 200
                        });
                });

            modelBuilder.Entity("Eentities.StorageEntity", b =>
                {
                    b.Property<string>("StorageId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("PartialQuantity")
                        .HasColumnType("int");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<string>("WhereHouseId")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("StorageId");

                    b.HasIndex("ProductId");

                    b.HasIndex("WhereHouseId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("Eentities.WhereHouseEntity", b =>
                {
                    b.Property<string>("WhereHouseId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("WhereHouseAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("WhereHouseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("WhereHouseId");

                    b.ToTable("Wherehouses");

                    b.HasData(
                        new
                        {
                            WhereHouseId = "5d2fe76f-567f-42eb-8d88-9b7ef934ed9c",
                            WhereHouseAddress = "Calle 8 con 23",
                            WhereHouseName = "Bodega Central"
                        },
                        new
                        {
                            WhereHouseId = "1259ee9c-edfe-4890-94a6-a6a16ea80103",
                            WhereHouseAddress = "Calle norte con occidente",
                            WhereHouseName = "Bodega Norte"
                        });
                });

            modelBuilder.Entity("Eentities.InputOutputEntity", b =>
                {
                    b.HasOne("Eentities.StorageEntity", "Storage")
                        .WithMany("InputOutputs")
                        .HasForeignKey("StorageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Storage");
                });

            modelBuilder.Entity("Eentities.ProductEntity", b =>
                {
                    b.HasOne("Eentities.CategoryEntity", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Eentities.StorageEntity", b =>
                {
                    b.HasOne("Eentities.ProductEntity", "Product")
                        .WithMany("Storages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Eentities.WhereHouseEntity", "WhereHouse")
                        .WithMany("Storages")
                        .HasForeignKey("WhereHouseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("WhereHouse");
                });

            modelBuilder.Entity("Eentities.CategoryEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Eentities.ProductEntity", b =>
                {
                    b.Navigation("Storages");
                });

            modelBuilder.Entity("Eentities.StorageEntity", b =>
                {
                    b.Navigation("InputOutputs");
                });

            modelBuilder.Entity("Eentities.WhereHouseEntity", b =>
                {
                    b.Navigation("Storages");
                });
#pragma warning restore 612, 618
        }
    }
}
