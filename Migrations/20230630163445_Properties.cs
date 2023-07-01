using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WateringService.Migrations
{
    /// <inheritdoc />
    public partial class Properties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RainGauges_Parks_ParkId",
                table: "RainGauges");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParkId",
                table: "RainGauges",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GaugeName",
                table: "RainGauges",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "Rainfall",
                table: "RainGauges",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_RainGauges_Parks_ParkId",
                table: "RainGauges",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "ParkId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RainGauges_Parks_ParkId",
                table: "RainGauges");

            migrationBuilder.DropColumn(
                name: "GaugeName",
                table: "RainGauges");

            migrationBuilder.DropColumn(
                name: "Rainfall",
                table: "RainGauges");

            migrationBuilder.AlterColumn<Guid>(
                name: "ParkId",
                table: "RainGauges",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_RainGauges_Parks_ParkId",
                table: "RainGauges",
                column: "ParkId",
                principalTable: "Parks",
                principalColumn: "ParkId");
        }
    }
}
