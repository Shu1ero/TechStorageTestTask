using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Contracts_EquipmentId",
                table: "Contracts",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FacilityId",
                table: "Contracts",
                column: "FacilityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Equipment_EquipmentId",
                table: "Contracts",
                column: "EquipmentId",
                principalTable: "Equipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Facilities_FacilityId",
                table: "Contracts",
                column: "FacilityId",
                principalTable: "Facilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Equipment_EquipmentId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Facilities_FacilityId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_EquipmentId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_FacilityId",
                table: "Contracts");
        }
    }
}
