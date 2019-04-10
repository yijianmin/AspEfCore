using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspEfCore.Data.Migrations
{
    public partial class UpdateSeedData7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("a1790c03-62fb-416b-aa1a-be1abbec9f46"),
                column: "Name",
                value: "李四");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Student",
                keyColumn: "Id",
                keyValue: new Guid("a1790c03-62fb-416b-aa1a-be1abbec9f46"),
                column: "Name",
                value: "张三1");
        }
    }
}
