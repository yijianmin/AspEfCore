using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspEfCore.Data.Migrations
{
    public partial class UpdateSeedData4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Name" },
                values: new object[] { new Guid("5a4f3157-0288-4b96-aa40-83e3f0289807"), "张三" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
