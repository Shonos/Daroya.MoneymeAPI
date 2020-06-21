using Microsoft.EntityFrameworkCore.Migrations;

namespace Daroya.MoneymeAPI.Database.Migrations
{
    public partial class morecolumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "EstablishmentFee",
                table: "Quotes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Repayments",
                table: "Quotes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalInterest",
                table: "Quotes",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstablishmentFee",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "Repayments",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "TotalInterest",
                table: "Quotes");
        }
    }
}
