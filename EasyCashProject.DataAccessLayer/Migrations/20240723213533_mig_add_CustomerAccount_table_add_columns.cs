using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashProject.DataAccessLayer.Migrations
{
    public partial class mig_add_CustomerAccount_table_add_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CVC",
                table: "CustomerAccounts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExpirationDate",
                table: "CustomerAccounts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVC",
                table: "CustomerAccounts");

            migrationBuilder.DropColumn(
                name: "ExpirationDate",
                table: "CustomerAccounts");
        }
    }
}
