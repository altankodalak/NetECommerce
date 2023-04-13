using Microsoft.EntityFrameworkCore.Migrations;

namespace NetEcommerce.DAL.Migrations
{
    public partial class addedOrderNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ordernumber",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ordernumber",
                table: "Orders");
        }
    }
}
