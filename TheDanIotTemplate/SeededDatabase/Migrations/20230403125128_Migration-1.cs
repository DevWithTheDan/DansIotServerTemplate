using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeededDatabase.Migrations
{
    /// <inheritdoc />
    public partial class Migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "CalculationData",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        ReferenceId = table.Column<int>(type: "int", nullable: false),
            //        Data = table.Column<int>(type: "int", nullable: false),
            //        Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CalculationData", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "CalculationReferences",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false),
            //        CalculationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        IsPositiveOnly = table.Column<bool>(type: "bit", nullable: false),
            //        IsNegativeOnly = table.Column<bool>(type: "bit", nullable: false),
            //        Max = table.Column<int>(type: "int", nullable: false),
            //        Min = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_CalculationReferences", x => x.Id);
            //    });

            migrationBuilder.CreateTable(
                name: "FrontendGauges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartAngle = table.Column<double>(type: "float", nullable: false),
                    EndAngle = table.Column<double>(type: "float", nullable: false),
                    Step = table.Column<double>(type: "float", nullable: false),
                    Min = table.Column<double>(type: "float", nullable: false),
                    Max = table.Column<double>(type: "float", nullable: false),
                    GaugeTickPosition = table.Column<int>(type: "int", nullable: false),
                    HeightPx = table.Column<int>(type: "int", nullable: false),
                    WidthPx = table.Column<int>(type: "int", nullable: false),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrontendGauges", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculationData");

            migrationBuilder.DropTable(
                name: "CalculationReferences");

            migrationBuilder.DropTable(
                name: "FrontendGauges");
        }
    }
}
