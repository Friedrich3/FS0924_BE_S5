using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS0924_BE_S5.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablesAndRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genere",
                table: "Libri");

            migrationBuilder.AddColumn<int>(
                name: "IdGenere",
                table: "Libri",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Libri_IdGenere",
                table: "Libri",
                column: "IdGenere");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Generi_IdGenere",
                table: "Libri",
                column: "IdGenere",
                principalTable: "Generi",
                principalColumn: "IdGenere",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Generi_IdGenere",
                table: "Libri");

            migrationBuilder.DropTable(
                name: "Generi");

            migrationBuilder.DropIndex(
                name: "IX_Libri_IdGenere",
                table: "Libri");

            migrationBuilder.DropColumn(
                name: "IdGenere",
                table: "Libri");

            migrationBuilder.AddColumn<string>(
                name: "Genere",
                table: "Libri",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
