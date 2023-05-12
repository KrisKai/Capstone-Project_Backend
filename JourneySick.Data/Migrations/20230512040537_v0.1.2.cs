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
                name: "fldRole",
                table: "tbluserdetail",
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
                name: "fldFullname",
                table: "tbluserdetail",
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
                name: "fldEmail",
                table: "tbluserdetail",
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
                name: "fldAddress",
                table: "tbluserdetail",
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
                name: "fldType",
                table: "tbltriprole",
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
                name: "fldConfirmation",
                table: "tbltripmember",
                type: "char(10)",
                fixedLength: true,
                maxLength: 10,
                nullable: true,
                defaultValueSql: "'NO'",
                collation: "latin1_swedish_ci")
                .Annotation("MySql:CharSet", "latin1");

            migrationBuilder.AddColumn<DateTime>(
                name: "fldSendDate",
                table: "tbltripmember",
                type: "datetime",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "fldTripStatus",
                table: "tbltrip",
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
                name: "fldTripName",
                table: "tbltrip",
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
                name: "fldConfirmation",
                table: "tbltripmember");

            migrationBuilder.DropColumn(
                name: "fldSendDate",
                table: "tbltripmember");

            migrationBuilder.AlterColumn<string>(
                name: "fldRole",
                table: "tbluserdetail",
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
                name: "fldFullname",
                table: "tbluserdetail",
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
                name: "fldEmail",
                table: "tbluserdetail",
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
                name: "fldAddress",
                table: "tbluserdetail",
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
                name: "fldType",
                table: "tbltriprole",
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
                name: "fldTripStatus",
                table: "tbltrip",
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
                name: "fldTripName",
                table: "tbltrip",
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
