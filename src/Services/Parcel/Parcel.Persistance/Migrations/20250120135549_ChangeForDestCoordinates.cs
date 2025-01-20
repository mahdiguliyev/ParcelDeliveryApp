using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Parcel.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForDestCoordinates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("8be1a8d9-a536-4ec2-aaec-8d6d51f71475"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ced38686-3b71-4fa1-a2e6-da87866f60ab"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("d6f7ebcb-055b-498c-89fb-88f22e4a8fc6"));

            migrationBuilder.AddColumn<string>(
                name: "CurrentCoortinates",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Coortinates", "CreatedByName", "CreatedDate", "CurierId", "CurrentCoortinates", "DestinationAddress", "IsActive", "IsDeleted", "ModifiedByName", "ModifiedDate", "OrderInfo", "PhoneNumber", "Status", "Title", "TotalPrice", "UserId", "Weight" },
                values: new object[,]
                {
                    { new Guid("1c159aa7-dee3-470c-904c-c4ceca0f43f1"), "Latitude: 51.507351-Longitude: -0.127758", "Admin", new DateTime(2025, 1, 20, 17, 55, 49, 348, DateTimeKind.Local).AddTicks(2678), null, null, "Baku, Sumgayiq 12 mkr", true, false, "Admin", new DateTime(2025, 1, 20, 17, 55, 49, 348, DateTimeKind.Local).AddTicks(2689), "Test information", "+994555555555", 0, "Grocery Essentials Pack (Vegetables, Dairy, Grains)", 70m, new Guid("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"), 1.2 },
                    { new Guid("32987ed0-4154-4fae-afa7-5b603ba12b19"), "Latitude: 51.507351-Longitude: -0.127758", "Admin", new DateTime(2025, 1, 20, 17, 55, 49, 348, DateTimeKind.Local).AddTicks(2724), null, null, "Baku, Sumgayiq 12 mkr", true, false, "Admin", new DateTime(2025, 1, 20, 17, 55, 49, 348, DateTimeKind.Local).AddTicks(2724), "Test information", "+994555555555", 0, "Wireless Bluetooth Headphones", 110m, new Guid("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"), 0.10000000000000001 },
                    { new Guid("87bae8af-3b03-442b-bbc6-edbad6651ef8"), "Latitude: 51.507351-Longitude: -0.127758", "Admin", new DateTime(2025, 1, 20, 17, 55, 49, 348, DateTimeKind.Local).AddTicks(2720), null, null, "Baku, Sumgayiq 12 mkr", true, false, "Admin", new DateTime(2025, 1, 20, 17, 55, 49, 348, DateTimeKind.Local).AddTicks(2720), "Test information", "+994555555555", 0, "Air Jordan Retro Sneakers", 254m, new Guid("ceb22d5e-1731-443c-8ba8-a7e26cc1b776"), 0.80000000000000004 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("1c159aa7-dee3-470c-904c-c4ceca0f43f1"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("32987ed0-4154-4fae-afa7-5b603ba12b19"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("87bae8af-3b03-442b-bbc6-edbad6651ef8"));

            migrationBuilder.DropColumn(
                name: "CurrentCoortinates",
                table: "Orders");

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
    }
}
