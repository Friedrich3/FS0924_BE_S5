using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FS0924_BE_S5.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTablesAndRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdGenere",
                table: "Libri",
                type: "int",
                nullable: false,
                defaultValueSql: "1",
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdGenere",
                table: "Libri",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValueSql: "1");
        }
    }
}
