using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashProject.DataAccessLayer.Migrations
{
    public partial class update_table_add_column_CreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedDate",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Contacts");
        }
    }
}
