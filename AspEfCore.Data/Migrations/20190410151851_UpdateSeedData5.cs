using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspEfCore.Data.Migrations
{
    public partial class UpdateSeedData5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("5a4f3157-0288-4b96-aa40-83e3f0289807"));

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("a1790c03-62fb-416b-aa1a-be1abbec9f46"), "张三1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("a1790c03-62fb-416b-aa1a-be1abbec9f46"));

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5a4f3157-0288-4b96-aa40-83e3f0289807"), "张三" });
        }
    }
}
