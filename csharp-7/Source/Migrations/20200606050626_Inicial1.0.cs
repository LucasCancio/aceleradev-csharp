using Microsoft.EntityFrameworkCore.Migrations;

namespace Source.Migrations
{
    public partial class Inicial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "challenge_id",
                table: "challenge",
                newName: "id");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "user",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<decimal>(
                name: "score",
                table: "submission",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "challenge",
                newName: "challenge_id");

            migrationBuilder.AlterColumn<string>(
                name: "password",
                table: "user",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<double>(
                name: "score",
                table: "submission",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
