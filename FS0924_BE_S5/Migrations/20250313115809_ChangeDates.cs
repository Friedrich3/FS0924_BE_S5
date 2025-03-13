using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS0924_BE_S5.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataInizio",
                table: "Ordini",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataScadenza",
                table: "Ordini",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInizio",
                table: "Ordini");

            migrationBuilder.DropColumn(
                name: "DataScadenza",
                table: "Ordini");
        }
    }
}
