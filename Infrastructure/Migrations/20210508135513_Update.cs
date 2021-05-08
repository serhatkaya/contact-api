using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Authentication",
                table: "Users",
                keyColumn: "Id",
                keyValue: "c0479570-10dc-4c0c-af00-0edd794b795a");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                schema: "Authentication",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Role",
                schema: "Authentication",
                table: "Users");

            migrationBuilder.InsertData(
                schema: "Authentication",
                table: "Users",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Deleted", "DeletedDate", "DeletedUser", "Name", "Password", "UpdatedDate", "UpdatedUser", "Username" },
                values: new object[] { "c0479570-10dc-4c0c-af00-0edd794b795a", new DateTime(2021, 5, 8, 7, 33, 4, 383, DateTimeKind.Utc).AddTicks(1708), 1, false, null, null, "Serhat KAYA", "9c2faed3417b8574fec3c80656e1466f", new DateTime(2021, 5, 8, 7, 33, 4, 383, DateTimeKind.Utc).AddTicks(2393), null, "s.kaya@kayaserhat.com" });
        }
    }
}
