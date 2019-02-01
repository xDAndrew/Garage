using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairsManager.Dal.Migrations
{
    public partial class vehicleHasNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Vehicle",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Vehicle",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
