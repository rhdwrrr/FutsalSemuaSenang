using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace FutsalSemuaSenang.Migrations
{
    public partial class booking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Booking",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IdUser = table.Column<string>(type: "text", nullable: true),
                    NamaLapangan = table.Column<string>(type: "text", nullable: true),
                    Tanggal = table.Column<DateTime>(type: "datetime", nullable: false),
                    JamMulai = table.Column<DateTime>(type: "datetime", nullable: false),
                    JamSelesai = table.Column<DateTime>(type: "datetime", nullable: false),
                    Harga = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Booking");
        }
    }
}
