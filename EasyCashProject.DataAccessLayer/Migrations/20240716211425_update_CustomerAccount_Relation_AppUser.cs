using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashProject.DataAccessLayer.Migrations
{
    public partial class update_CustomerAccount_Relation_AppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserID",
                table: "CustomerAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerAccountID",
                table: "CustomerAccountProcesses",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerAccountID1",
                table: "CustomerAccountProcesses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccounts_AppUserID",
                table: "CustomerAccounts",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountProcesses_CustomerAccountID",
                table: "CustomerAccountProcesses",
                column: "CustomerAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAccountProcesses_CustomerAccountID1",
                table: "CustomerAccountProcesses",
                column: "CustomerAccountID1");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_CustomerAccountID",
                table: "CustomerAccountProcesses",
                column: "CustomerAccountID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_CustomerAccountID1",
                table: "CustomerAccountProcesses",
                column: "CustomerAccountID1",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccounts_AspNetUsers_AppUserID",
                table: "CustomerAccounts",
                column: "AppUserID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_CustomerAccountID",
                table: "CustomerAccountProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_CustomerAccountID1",
                table: "CustomerAccountProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccounts_AspNetUsers_AppUserID",
                table: "CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccounts_AppUserID",
                table: "CustomerAccounts");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountProcesses_CustomerAccountID",
                table: "CustomerAccountProcesses");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAccountProcesses_CustomerAccountID1",
                table: "CustomerAccountProcesses");

            migrationBuilder.DropColumn(
                name: "AppUserID",
                table: "CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "CustomerAccountID",
                table: "CustomerAccountProcesses");

            migrationBuilder.DropColumn(
                name: "CustomerAccountID1",
                table: "CustomerAccountProcesses");
        }
    }
}
