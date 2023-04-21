using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JourneySick.Data.Migrations
{
    public partial class v011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fldTripDestinationLocationAddress",
                table: "tbltripdetail");

            migrationBuilder.DropColumn(
                name: "fldTripDestinationLocationName",
                table: "tbltripdetail");

            migrationBuilder.DropColumn(
                name: "fldTripStartLocationAddress",
                table: "tbltripdetail");

            migrationBuilder.DropColumn(
                name: "fldTripStartLocationName",
                table: "tbltripdetail");

            migrationBuilder.DropColumn(
                name: "fldEstimateArrivalTime",
                table: "tbltrip");

            migrationBuilder.DropColumn(
                name: "fldEstimateStartTime",
                table: "tbltrip");

            migrationBuilder.AddColumn<decimal>(
                name: "fldDistance",
                table: "tbltripdetail",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: true,
                defaultValueSql: "'0.00'");

            migrationBuilder.AddColumn<DateOnly>(
                name: "fldEstimateEndDate",
                table: "tbltripdetail",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fldEstimateEndTime",
                table: "tbltripdetail",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "'HH:MM'",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<DateOnly>(
                name: "fldEstimateStartDate",
                table: "tbltripdetail",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fldEstimateStartTime",
                table: "tbltripdetail",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "'HH:MM'",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<int>(
                name: "fldTripDestinationLocationId",
                table: "tbltripdetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fldTripStartLocationId",
                table: "tbltripdetail",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fldTripPresenter",
                table: "tbltrip",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.AlterColumn<string>(
                name: "fldTripName",
                table: "tbltrip",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldCollation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<string>(
                name: "fldTripId",
                table: "tbltrip",
                type: "varchar(20)",
                maxLength: 20,
                nullable: false,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50)
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.CreateTable(
                name: "tblrouteplan",
                columns: table => new
                {
                    fldPlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fldRouteId = table.Column<int>(type: "int", nullable: true),
                    fldPlanDescription = table.Column<string>(type: "tinytext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.fldPlanId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "tbltriproute",
                columns: table => new
                {
                    fldRouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fldTripid = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fldMapId = table.Column<int>(type: "int", nullable: true),
                    fldPriority = table.Column<int>(type: "int", nullable: true),
                    fldEstimateTime = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true, defaultValueSql: "'0.00'"),
                    fldDistance = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.fldRouteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblrouteplan");

            migrationBuilder.DropTable(
                name: "tbltriproute");

            migrationBuilder.DropColumn(
                name: "fldDistance",
                table: "tbltripdetail");

            migrationBuilder.DropColumn(
                name: "fldEstimateEndDate",
                table: "tbltripdetail");

            migrationBuilder.DropColumn(
                name: "fldEstimateEndTime",
                table: "tbltripdetail");

            migrationBuilder.DropColumn(
                name: "fldEstimateStartDate",
                table: "tbltripdetail");

            migrationBuilder.DropColumn(
                name: "fldEstimateStartTime",
                table: "tbltripdetail");

            migrationBuilder.DropColumn(
                name: "fldTripDestinationLocationId",
                table: "tbltripdetail");

            migrationBuilder.DropColumn(
                name: "fldTripStartLocationId",
                table: "tbltripdetail");

            migrationBuilder.AddColumn<string>(
                name: "fldTripDestinationLocationAddress",
                table: "tbltripdetail",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "fldTripDestinationLocationName",
                table: "tbltripdetail",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "fldTripStartLocationAddress",
                table: "tbltripdetail",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "fldTripStartLocationName",
                table: "tbltripdetail",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "fldTripPresenter",
                table: "tbltrip",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.AlterColumn<string>(
                name: "fldTripName",
                table: "tbltrip",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldCollation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<string>(
                name: "fldTripId",
                table: "tbltrip",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                collation: "latin1_swedish_ci",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20)
                .Annotation("MySql:CharSet", "latin1")
                .OldAnnotation("MySql:CharSet", "latin1")
                .OldAnnotation("Relational:Collation", "latin1_swedish_ci");

            migrationBuilder.AddColumn<DateTime>(
                name: "fldEstimateArrivalTime",
                table: "tbltrip",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fldEstimateStartTime",
                table: "tbltrip",
                type: "datetime",
                nullable: true);
        }
    }
}
