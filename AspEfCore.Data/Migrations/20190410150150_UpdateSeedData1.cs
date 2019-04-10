using Microsoft.EntityFrameworkCore.Migrations;

namespace AspEfCore.Data.Migrations
{
    public partial class UpdateSeedData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name", "Population" },
                values: new object[] { 4, "四川省", 100000222 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name", "Population" },
                values: new object[] { 3, "四川省", 100000222 });
        }
    }
}
