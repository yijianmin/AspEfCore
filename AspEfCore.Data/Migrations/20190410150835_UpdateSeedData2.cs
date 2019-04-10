using Microsoft.EntityFrameworkCore.Migrations;

namespace AspEfCore.Data.Migrations
{
    public partial class UpdateSeedData2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "Id", "Name", "Population" },
                values: new object[] { 6, "江苏省", 80000000 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "AreaCode", "Name", "ProvinceId" },
                values: new object[] { 61, null, "南京", 6 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "AreaCode", "Name", "ProvinceId" },
                values: new object[] { 62, null, "苏州", 6 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "AreaCode", "Name", "ProvinceId" },
                values: new object[] { 63, null, "连云港", 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Provinces",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
