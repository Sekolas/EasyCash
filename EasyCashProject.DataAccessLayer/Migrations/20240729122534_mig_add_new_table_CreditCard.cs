using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyCashProject.DataAccessLayer.Migrations
{
    public partial class mig_add_new_table_CreditCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreditCards",
                columns: table => new
                {
                    CreditCardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditCardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVC = table.Column<int>(type: "int", nullable: true),
                    ExpirationDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditCardBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BankBranch = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditCardStatus = table.Column<bool>(type: "bit", nullable: false),
                    AppUserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCards", x => x.CreditCardID);
                    table.ForeignKey(
                        name: "FK_CreditCards_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CreditCards_AppUserID",
                table: "CreditCards",
                column: "AppUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreditCards");
        }
    }
}
