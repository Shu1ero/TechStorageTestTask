using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Equipment",
                columns: new[] { "Id", "Area", "Name" },
                values: new object[,]
                {
                    { 1, 20.0, "Equip1" },
                    { 2, 15.0, "Equip2" },
                    { 3, 10.0, "Equip3" }
                });

            migrationBuilder.InsertData(
                table: "Facilities",
                columns: new[] { "Id", "Capacity", "Name" },
                values: new object[,]
                {
                    { 1, 100.0, "test1" },
                    { 2, 150.0, "test2" },
                    { 3, 200.0, "test3" }
                });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "EquipmentId", "FacilityId", "Quantity" },
                values: new object[] { 1, 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "EquipmentId", "FacilityId", "Quantity" },
                values: new object[] { 2, 2, 1, 2 });

            migrationBuilder.InsertData(
                table: "Contracts",
                columns: new[] { "Id", "EquipmentId", "FacilityId", "Quantity" },
                values: new object[] { 3, 3, 2, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contracts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equipment",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Facilities",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
