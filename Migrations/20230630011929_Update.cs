using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WateringService.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Binomial",
                table: "Trees",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "Gallons",
                table: "Trees",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gallons",
                table: "Trees");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Trees",
                newName: "Binomial");
        }
    }
}
