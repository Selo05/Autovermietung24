using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autovermietung24.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Karosserieform = table.Column<string>(type: "TEXT", nullable: false),
                    Getriebe = table.Column<string>(type: "TEXT", nullable: false),
                    Kraftstoff = table.Column<string>(type: "TEXT", nullable: false),
                    Marke = table.Column<string>(type: "TEXT", nullable: false),
                    Model = table.Column<string>(type: "TEXT", nullable: false),
                    Jahr = table.Column<int>(type: "INTEGER", nullable: false),
                    Kennzeichen = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kunden",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stammkunde = table.Column<bool>(type: "INTEGER", nullable: false),
                    Nachname = table.Column<string>(type: "TEXT", nullable: false),
                    Vorname = table.Column<string>(type: "TEXT", nullable: false),
                    Geburtsdatum = table.Column<string>(type: "TEXT", nullable: false),
                    Geburtsort = table.Column<string>(type: "TEXT", nullable: false),
                    Anschrift = table.Column<string>(type: "TEXT", nullable: false),
                    Staatsangehörigkeit = table.Column<string>(type: "TEXT", nullable: false),
                    Ausweisnummer = table.Column<string>(type: "TEXT", nullable: false),
                    Führerscheinnummer = table.Column<string>(type: "TEXT", nullable: false),
                    Gültigkeitsfrist = table.Column<string>(type: "TEXT", nullable: false),
                    FahrerlaubnisklasseB = table.Column<bool>(type: "INTEGER", nullable: false),
                    Zusatzangaben = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kunden", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Kunden");
        }
    }
}
