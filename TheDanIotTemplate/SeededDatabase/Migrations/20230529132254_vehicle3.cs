using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeededDatabase.Migrations
{
    /// <inheritdoc />
    public partial class vehicle3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManfucteruerId",
                table: "VehicleModels",
                newName: "ManufacturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ManufacturerId",
                table: "VehicleModels",
                newName: "ManfucteruerId");
        }
    }
}
