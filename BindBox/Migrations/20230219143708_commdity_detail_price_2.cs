using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BindBox.Migrations
{
    public partial class commdity_detail_price_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "OfficiaPrice",
                schema: "ro",
                table: "box_commodity_detail",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ComminfoPrice",
                schema: "ro",
                table: "box_commodity_detail",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "money");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "OfficiaPrice",
                schema: "ro",
                table: "box_commodity_detail",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ComminfoPrice",
                schema: "ro",
                table: "box_commodity_detail",
                type: "money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
