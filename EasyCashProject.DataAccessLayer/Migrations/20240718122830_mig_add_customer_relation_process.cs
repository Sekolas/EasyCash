using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashProject.DataAccessLayer.Migrations
{
    public partial class mig_add_customer_relation_process : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_CustomerAccountID",
                table: "CustomerAccountProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_CustomerAccountID1",
                table: "CustomerAccountProcesses");

            migrationBuilder.RenameColumn(
                name: "CustomerAccountID1",
                table: "CustomerAccountProcesses",
                newName: "SenderID");

            migrationBuilder.RenameColumn(
                name: "CustomerAccountID",
                table: "CustomerAccountProcesses",
                newName: "ReceiverID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccountProcesses_CustomerAccountID1",
                table: "CustomerAccountProcesses",
                newName: "IX_CustomerAccountProcesses_SenderID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccountProcesses_CustomerAccountID",
                table: "CustomerAccountProcesses",
                newName: "IX_CustomerAccountProcesses_ReceiverID");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "CustomerAccountProcesses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_ReceiverID",
                table: "CustomerAccountProcesses",
                column: "ReceiverID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_SenderID",
                table: "CustomerAccountProcesses",
                column: "SenderID",
                principalTable: "CustomerAccounts",
                principalColumn: "CustomerAccountID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_ReceiverID",
                table: "CustomerAccountProcesses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAccountProcesses_CustomerAccounts_SenderID",
                table: "CustomerAccountProcesses");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "CustomerAccountProcesses");

            migrationBuilder.RenameColumn(
                name: "SenderID",
                table: "CustomerAccountProcesses",
                newName: "CustomerAccountID1");

            migrationBuilder.RenameColumn(
                name: "ReceiverID",
                table: "CustomerAccountProcesses",
                newName: "CustomerAccountID");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccountProcesses_SenderID",
                table: "CustomerAccountProcesses",
                newName: "IX_CustomerAccountProcesses_CustomerAccountID1");

            migrationBuilder.RenameIndex(
                name: "IX_CustomerAccountProcesses_ReceiverID",
                table: "CustomerAccountProcesses",
                newName: "IX_CustomerAccountProcesses_CustomerAccountID");

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
        }
    }
}
