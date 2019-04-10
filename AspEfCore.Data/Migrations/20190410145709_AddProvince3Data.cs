using Microsoft.EntityFrameworkCore.Migrations;

namespace AspEfCore.Data.Migrations
{
    public partial class AddProvince3Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name", "Population" },
                values: new object[] { 3, "四川", 100000000 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
