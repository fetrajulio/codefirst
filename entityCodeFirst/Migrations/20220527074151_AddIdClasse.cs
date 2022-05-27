using Microsoft.EntityFrameworkCore.Migrations;

namespace entityCodeFirst.Migrations
{
    public partial class AddIdClasse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdClasse",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdClasse",
                table: "Persons");
        }
    }
}
