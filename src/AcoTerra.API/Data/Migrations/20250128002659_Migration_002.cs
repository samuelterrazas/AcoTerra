using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcoTerra.API.Data.Migrations
{
    /// <inheritdoc />
    public partial class Migration_002 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_technical_information_vehicle_id",
                table: "technical_information");

            migrationBuilder.DropIndex(
                name: "ix_financial_information_vehicle_id",
                table: "financial_information");

            migrationBuilder.DropColumn(
                name: "vehicle_id",
                table: "technical_information");

            migrationBuilder.DropColumn(
                name: "vehicle_id",
                table: "financial_information");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "vehicle_id",
                table: "technical_information",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "vehicle_id",
                table: "financial_information",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_technical_information_vehicle_id",
                table: "technical_information",
                column: "vehicle_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_financial_information_vehicle_id",
                table: "financial_information",
                column: "vehicle_id",
                unique: true);
        }
    }
}
