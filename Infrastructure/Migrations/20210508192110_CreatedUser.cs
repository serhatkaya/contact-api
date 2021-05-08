using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class CreatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: "eae2e0ee-1ec2-4ba7-bf8d-c730f2d4e498");

            migrationBuilder.DeleteData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: "eb1ca622-320b-4ea8-bfe6-31022d0062e7");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUser",
                schema: "Authentication",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUser",
                schema: "Application",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedUser",
                schema: "Application",
                table: "ContactGroups",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "Authentication",
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Deleted", "DeletedDate", "DeletedUser", "Name", "Password", "Role", "UpdatedDate", "UpdatedUser", "Username" },
                values: new object[] { "3ee0d083-c2f8-4654-8339-fe715583530b", null, null, false, null, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                schema: "Authentication",
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Deleted", "DeletedDate", "DeletedUser", "Name", "Password", "Role", "UpdatedDate", "UpdatedUser", "Username" },
                values: new object[] { "33c65341-822c-4d55-8d50-15cabeda5c90", new DateTime(2021, 5, 8, 19, 21, 10, 631, DateTimeKind.Utc).AddTicks(5083), "621fd2a7-494b-4c5e-a2b9-31b0df281a56", false, null, null, "Serhat KAYA", "9c2faed3417b8574fec3c80656e1466f", null, new DateTime(2021, 5, 8, 19, 21, 10, 631, DateTimeKind.Utc).AddTicks(5830), null, "s.kaya@kayaserhat.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: "33c65341-822c-4d55-8d50-15cabeda5c90");

            migrationBuilder.DeleteData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: "3ee0d083-c2f8-4654-8339-fe715583530b");

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUser",
                schema: "Authentication",
                table: "Users",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUser",
                schema: "Application",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CreatedUser",
                schema: "Application",
                table: "ContactGroups",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                schema: "Authentication",
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Deleted", "DeletedDate", "DeletedUser", "Name", "Password", "Role", "UpdatedDate", "UpdatedUser", "Username" },
                values: new object[] { "eb1ca622-320b-4ea8-bfe6-31022d0062e7", null, null, false, null, null, null, null, null, null, null, null });

            migrationBuilder.InsertData(
                schema: "Authentication",
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Deleted", "DeletedDate", "DeletedUser", "Name", "Password", "Role", "UpdatedDate", "UpdatedUser", "Username" },
                values: new object[] { "eae2e0ee-1ec2-4ba7-bf8d-c730f2d4e498", new DateTime(2021, 5, 8, 13, 55, 13, 32, DateTimeKind.Utc).AddTicks(4414), 1, false, null, null, "Serhat KAYA", "9c2faed3417b8574fec3c80656e1466f", null, new DateTime(2021, 5, 8, 13, 55, 13, 32, DateTimeKind.Utc).AddTicks(5165), null, "s.kaya@kayaserhat.com" });
        }
    }
}
