using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parcel.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DestinationAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Coortinates = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    OrderInfo = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CurierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedByName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Coortinates", "CreatedByName", "CreatedDate", "CurierId", "DestinationAddress", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "OrderInfo", "PhoneNumber", "Status", "Title", "TotalPrice", "UserId", "Weight" },
                values: new object[,]
                {
                    { new Guid("8be1a8d9-a536-4ec2-aaec-8d6d51f71475"), "Latitude: 51.507351-Longitude: -0.127758", "Admin", new DateTime(2025, 1, 19, 16, 47, 31, 253, DateTimeKind.Local).AddTicks(3042), null, "Baku, Sumgayiq 12 mkr", true, false, "Admin", new DateTime(2025, 1, 19, 16, 47, 31, 253, DateTimeKind.Local).AddTicks(3055), "Test information", "+994555555555", 0, "Grocery Essentials Pack (Vegetables, Dairy, Grains)", 70m, new Guid("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"), 1.2 },
                    { new Guid("ced38686-3b71-4fa1-a2e6-da87866f60ab"), "Latitude: 51.507351-Longitude: -0.127758", "Admin", new DateTime(2025, 1, 19, 16, 47, 31, 253, DateTimeKind.Local).AddTicks(3093), null, "Baku, Sumgayiq 12 mkr", true, false, "Admin", new DateTime(2025, 1, 19, 16, 47, 31, 253, DateTimeKind.Local).AddTicks(3093), "Test information", "+994555555555", 0, "Air Jordan Retro Sneakers", 254m, new Guid("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"), 0.80000000000000004 },
                    { new Guid("d6f7ebcb-055b-498c-89fb-88f22e4a8fc6"), "Latitude: 51.507351-Longitude: -0.127758", "Admin", new DateTime(2025, 1, 19, 16, 47, 31, 253, DateTimeKind.Local).AddTicks(3107), null, "Baku, Sumgayiq 12 mkr", true, false, "Admin", new DateTime(2025, 1, 19, 16, 47, 31, 253, DateTimeKind.Local).AddTicks(3107), "Test information", "+994555555555", 0, "Wireless Bluetooth Headphones", 110m, new Guid("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"), 0.10000000000000001 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
