using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bragi.DataLayer.Migrations.ImiDb
{
    public partial class initialmain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "T01_Etickets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ModificatedBy = table.Column<string>(maxLength: 100, nullable: true),
                    ModificationDate = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    ApplicationId = table.Column<int>(nullable: false),
                    Names = table.Column<string>(nullable: true),
                    LastNames = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    PassportNumber = table.Column<string>(nullable: true),
                    IsUsed = table.Column<bool>(nullable: false),
                    EntradaSalida = table.Column<string>(nullable: true),
                    EmissionDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T01_Etickets", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T01_Etickets",
                schema: "dbo");
        }
    }
}
