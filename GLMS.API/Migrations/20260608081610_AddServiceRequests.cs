using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GLMS.API.Migrations
{
    /// <inheritdoc />
    public partial class AddServiceRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cost",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "CostInUSD",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "RequestType",
                table: "ServiceRequests");

            migrationBuilder.AddColumn<decimal>(
                name: "USDAmount",
                table: "ServiceRequests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ZARAmount",
                table: "ServiceRequests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "USDAmount",
                table: "ServiceRequests");

            migrationBuilder.DropColumn(
                name: "ZARAmount",
                table: "ServiceRequests");

            migrationBuilder.AddColumn<decimal>(
                name: "Cost",
                table: "ServiceRequests",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "CostInUSD",
                table: "ServiceRequests",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "RequestType",
                table: "ServiceRequests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
