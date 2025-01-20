﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Parcel.Persistance.Context;

#nullable disable

namespace Parcel.Persistance.Migrations
{
    [DbContext(typeof(ParcelContext))]
    partial class ParcelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Parcel.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Coortinates")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CurierId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CurrentCoortinates")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DestinationAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderInfo")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("RejectReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Orders", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("2f6acfeb-1bcc-4d70-a7ee-4f0b3586a860"),
                            Coortinates = "Latitude: 51.507351-Longitude: -0.127758",
                            CreatedByName = "Admin",
                            CreatedDate = new DateTime(2025, 1, 20, 19, 2, 47, 654, DateTimeKind.Local).AddTicks(1358),
                            DestinationAddress = "Baku, Sumgayiq 12 mkr",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "Admin",
                            ModifiedDate = new DateTime(2025, 1, 20, 19, 2, 47, 654, DateTimeKind.Local).AddTicks(1370),
                            OrderInfo = "Test information",
                            PhoneNumber = "+994555555555",
                            Status = 0,
                            Title = "Grocery Essentials Pack (Vegetables, Dairy, Grains)",
                            TotalPrice = 70m,
                            UserId = new Guid("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"),
                            Weight = 1.2
                        },
                        new
                        {
                            Id = new Guid("775f86f4-2e85-4536-9a59-8bd8d96974dd"),
                            Coortinates = "Latitude: 51.507351-Longitude: -0.127758",
                            CreatedByName = "Admin",
                            CreatedDate = new DateTime(2025, 1, 20, 19, 2, 47, 654, DateTimeKind.Local).AddTicks(1411),
                            DestinationAddress = "Baku, Sumgayiq 12 mkr",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "Admin",
                            ModifiedDate = new DateTime(2025, 1, 20, 19, 2, 47, 654, DateTimeKind.Local).AddTicks(1411),
                            OrderInfo = "Test information",
                            PhoneNumber = "+994555555555",
                            Status = 0,
                            Title = "Air Jordan Retro Sneakers",
                            TotalPrice = 254m,
                            UserId = new Guid("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"),
                            Weight = 0.80000000000000004
                        },
                        new
                        {
                            Id = new Guid("363d1d32-a7a3-436d-970d-2976f9f742fa"),
                            Coortinates = "Latitude: 51.507351-Longitude: -0.127758",
                            CreatedByName = "Admin",
                            CreatedDate = new DateTime(2025, 1, 20, 19, 2, 47, 654, DateTimeKind.Local).AddTicks(1414),
                            DestinationAddress = "Baku, Sumgayiq 12 mkr",
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "Admin",
                            ModifiedDate = new DateTime(2025, 1, 20, 19, 2, 47, 654, DateTimeKind.Local).AddTicks(1415),
                            OrderInfo = "Test information",
                            PhoneNumber = "+994555555555",
                            Status = 0,
                            Title = "Wireless Bluetooth Headphones",
                            TotalPrice = 110m,
                            UserId = new Guid("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"),
                            Weight = 0.10000000000000001
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
