using Microsoft.EntityFrameworkCore.Migrations;

namespace Vm.Data.Migrations
{
    public partial class Active : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Providers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Adresses",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Providers");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Adresses");
        }
    }
}
