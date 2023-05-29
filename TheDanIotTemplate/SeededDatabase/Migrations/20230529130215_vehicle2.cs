using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeededDatabase.Migrations
{
    /// <inheritdoc />
    public partial class vehicle2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
               name: "VehicleOwners",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_VechicleOwners", x => x.Id);
               });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
