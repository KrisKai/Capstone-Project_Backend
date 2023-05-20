using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JourneySick.Data.Migrations
{
    public partial class v012 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "userdetail",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldCollation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "userdetail",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldCollation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "userdetail",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldCollation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "userdetail",
                type: "longtext",
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldCollation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "triprole",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldCollation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AddColumn<string>(
                name: "Confirmation",
                table: "tripmember",
                type: "char(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                defaultValueSql: "'NO'",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<DateTime>(
                name: "SendDate",
                table: "tripmember",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TripStatus",
                table: "trip",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldCollation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8");

            migrationBuilder.AlterColumn<string>(
                name: "TripName",
                table: "trip",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8mb3_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldCollation: "utf8_general_ci")
                .Annotation("MySql:CharSet", "utf8mb3")
                .OldAnnotation("MySql:CharSet", "utf8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Confirmation",
                table: "tripmember");

            migrationBuilder.DropColumn(
                name: "SendDate",
                table: "tripmember");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "userdetail",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldCollation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AlterColumn<string>(
                name: "Fullname",
                table: "userdetail",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldCollation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "userdetail",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldCollation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "userdetail",
                type: "longtext",
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true,
                oldCollation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AlterColumn<string>(
                name: "Type",
                table: "triprole",
                type: "varchar(20)",
                maxLength: 20,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldMaxLength: 20,
                oldNullable: true,
                oldCollation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AlterColumn<string>(
                name: "TripStatus",
                table: "trip",
                type: "varchar(50)",
                maxLength: 50,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50,
                oldNullable: true,
                oldCollation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8mb3");

            migrationBuilder.AlterColumn<string>(
                name: "TripName",
                table: "trip",
                type: "varchar(100)",
                maxLength: 100,
                nullable: true,
                collation: "utf8_general_ci",
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100,
                oldNullable: true,
                oldCollation: "utf8mb3_general_ci")
                .Annotation("MySql:CharSet", "utf8")
                .OldAnnotation("MySql:CharSet", "utf8mb3");
        }
    }
}
