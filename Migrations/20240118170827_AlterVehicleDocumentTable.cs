using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arghiroiu_Raluca_Proiect.Migrations
{
    public partial class AlterVehicleDocumentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleDocument_VehicleDocumentType_TypeId1",
                table: "VehicleDocument");

            migrationBuilder.DropTable(
                name: "VehicleDocumentType");

            migrationBuilder.DropIndex(
                name: "IX_VehicleDocument_TypeId1",
                table: "VehicleDocument");

            migrationBuilder.DropColumn(
                name: "TypeId1",
                table: "VehicleDocument");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "VehicleDocument",
                newName: "Type");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "VehicleDocument",
                newName: "TypeId");

            migrationBuilder.AddColumn<string>(
                name: "TypeId1",
                table: "VehicleDocument",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "VehicleDocumentType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleDocumentType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDocument_TypeId1",
                table: "VehicleDocument",
                column: "TypeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleDocument_VehicleDocumentType_TypeId1",
                table: "VehicleDocument",
                column: "TypeId1",
                principalTable: "VehicleDocumentType",
                principalColumn: "Id");
        }
    }
}
