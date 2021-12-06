using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData123.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "City", "Name", "Phone" },
                values: new object[,]
                {
                    { 10001, "Örebro", "Adam Bertilson", "010-1234567" },
                    { 10002, "Ystad", "Caesar Davidsson", "020-910020" },
                    { 10003, "Ängelholm", "Erijk Filipsson", "030-65433741" },
                    { 10005, "Halmstad", "Gustav Helgesson", "040-98765414" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 10001);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 10002);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 10003);

            migrationBuilder.DeleteData(
                table: "Persons",
                keyColumn: "Id",
                keyValue: 10005);
        }
    }
}
