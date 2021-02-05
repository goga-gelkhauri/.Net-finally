using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Identity.Migrations
{
    public partial class InitialModel1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyHistory_User_UserId1",
                schema: "Identity",
                table: "CurrencyHistory");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyHistory_UserId1",
                schema: "Identity",
                table: "CurrencyHistory");

            migrationBuilder.DropColumn(
                name: "UserId1",
                schema: "Identity",
                table: "CurrencyHistory");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "Identity",
                table: "CurrencyHistory",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyHistory_UserId",
                schema: "Identity",
                table: "CurrencyHistory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyHistory_User_UserId",
                schema: "Identity",
                table: "CurrencyHistory",
                column: "UserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyHistory_User_UserId",
                schema: "Identity",
                table: "CurrencyHistory");

            migrationBuilder.DropIndex(
                name: "IX_CurrencyHistory_UserId",
                schema: "Identity",
                table: "CurrencyHistory");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "Identity",
                table: "CurrencyHistory",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                schema: "Identity",
                table: "CurrencyHistory",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyHistory_UserId1",
                schema: "Identity",
                table: "CurrencyHistory",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyHistory_User_UserId1",
                schema: "Identity",
                table: "CurrencyHistory",
                column: "UserId1",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
