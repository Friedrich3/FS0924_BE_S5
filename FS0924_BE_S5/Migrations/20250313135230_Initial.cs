using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS0924_BE_S5.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Generi",
                columns: table => new
                {
                    IdGenere = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generi", x => x.IdGenere);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    IdUtente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.IdUtente);
                });

            migrationBuilder.CreateTable(
                name: "Libri",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titolo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Autore = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IdGenere = table.Column<int>(type: "int", nullable: false),
                    Disponibilita = table.Column<bool>(type: "bit", nullable: false),
                    Copertina = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libri_Generi_IdGenere",
                        column: x => x.IdGenere,
                        principalTable: "Generi",
                        principalColumn: "IdGenere",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ordini",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LibroId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UtenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInizio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataScadenza = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordini", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ordini_Libri_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ordini_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "IdUtente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libri_IdGenere",
                table: "Libri",
                column: "IdGenere");

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_LibroId",
                table: "Ordini",
                column: "LibroId");

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_UtenteId",
                table: "Ordini",
                column: "UtenteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordini");

            migrationBuilder.DropTable(
                name: "Libri");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Generi");
        }
    }
}
