using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class UpdateEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
