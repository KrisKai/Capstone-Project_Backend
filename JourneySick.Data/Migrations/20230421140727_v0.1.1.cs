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
                name: "TripDestinationLocationAddress",
                table: "tripdetail");

            migrationBuilder.DropColumn(
                name: "TripDestinationLocationName",
                table: "tripdetail");

            migrationBuilder.DropColumn(
                name: "TripStartLocationAddress",
                table: "tripdetail");

            migrationBuilder.DropColumn(
                name: "TripStartLocationName",
                table: "tripdetail");

            migrationBuilder.DropColumn(
                name: "EstimateArrivalTime",
                table: "trip");

            migrationBuilder.DropColumn(
                name: "EstimateStartTime",
                table: "trip");

            migrationBuilder.AddColumn<decimal>(
                name: "Distance",
                table: "tripdetail",
                type: "decimal(12,2)",
                precision: 12,
                scale: 2,
                nullable: true,
                defaultValueSql: "'0.00'");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EstimateEndDate",
                table: "tripdetail",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstimateEndTime",
                table: "tripdetail",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "'HH:MM'",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<DateOnly>(
                name: "EstimateStartDate",
                table: "tripdetail",
                type: "date",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstimateStartTime",
                table: "tripdetail",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true,
                comment: "'HH:MM'",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<int>(
                name: "TripDestinationLocationId",
                table: "tripdetail",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TripStartLocationId",
                table: "tripdetail",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TripPresenter",
                table: "trip",
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
                name: "TripName",
                table: "trip",
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
                name: "TripId",
                table: "trip",
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
                name: "routeplan",
                columns: table => new
                {
                    PlanId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RouteId = table.Column<int>(type: "int", nullable: true),
                    PlanDescription = table.Column<string>(type: "tinytext", nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.PlanId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "triproute",
                columns: table => new
                {
                    RouteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tripid = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MapId = table.Column<int>(type: "int", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    EstimateTime = table.Column<decimal>(type: "decimal(5,2)", precision: 5, scale: 2, nullable: true, defaultValueSql: "'0.00'"),
                    Distance = table.Column<decimal>(type: "decimal(12,2)", precision: 12, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.RouteId);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "routeplan");

            migrationBuilder.DropTable(
                name: "triproute");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "tripdetail");

            migrationBuilder.DropColumn(
                name: "EstimateEndDate",
                table: "tripdetail");

            migrationBuilder.DropColumn(
                name: "EstimateEndTime",
                table: "tripdetail");

            migrationBuilder.DropColumn(
                name: "EstimateStartDate",
                table: "tripdetail");

            migrationBuilder.DropColumn(
                name: "EstimateStartTime",
                table: "tripdetail");

            migrationBuilder.DropColumn(
                name: "TripDestinationLocationId",
                table: "tripdetail");

            migrationBuilder.DropColumn(
                name: "TripStartLocationId",
                table: "tripdetail");

            migrationBuilder.AddColumn<string>(
                name: "TripDestinationLocationAddress",
                table: "tripdetail",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "TripDestinationLocationName",
                table: "tripdetail",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "TripStartLocationAddress",
                table: "tripdetail",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "TripStartLocationName",
                table: "tripdetail",
                type: "varchar(150)",
                maxLength: 150,
                nullable: true,
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AlterColumn<string>(
                name: "TripPresenter",
                table: "trip",
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
                name: "TripName",
                table: "trip",
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
                name: "TripId",
                table: "trip",
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
                name: "EstimateArrivalTime",
                table: "trip",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EstimateStartTime",
                table: "trip",
                type: "datetime",
                nullable: true);
        }
    }
}
