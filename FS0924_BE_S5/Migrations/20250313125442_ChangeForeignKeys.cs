using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS0924_BE_S5.Migrations
{
    /// <inheritdoc />
    public partial class ChangeForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUtente",
                table: "Ordini");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IdUtente",
                table: "Ordini",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
