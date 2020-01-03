using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Acme.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "Activity", "Comment", "Email", "FirstName", "LastName" },
                values: new object[] { new Guid("04758205-651c-413b-aeff-88f2b410149c"), "Escape Room", "Yay!", "pascal@siakim.com", "Pascal", "Siakim" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: new Guid("04758205-651c-413b-aeff-88f2b410149c"));
        }
    }
}
