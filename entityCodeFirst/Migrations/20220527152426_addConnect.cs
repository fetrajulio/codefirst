using Microsoft.EntityFrameworkCore.Migrations;

namespace entityCodeFirst.Migrations
{
    public partial class addConnect : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Connect",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Connect",
                table: "Persons");
        }
    }
}
