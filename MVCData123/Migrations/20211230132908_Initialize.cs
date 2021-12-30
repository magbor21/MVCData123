using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCData123.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    CurrentCountryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CurrentCountryID",
                        column: x => x.CurrentCountryID,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 30, nullable: false),
                    Phone = table.Column<string>(maxLength: 15, nullable: false),
                    CurrentCityID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Persons_Cities_CurrentCityID",
                        column: x => x.CurrentCityID,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonLanguages",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguages", x => new { x.PersonId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_PersonLanguages_Languages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguages_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10001, "Norway" },
                    { 10002, "Denmark" },
                    { 10003, "Finland" },
                    { 10004, "Canada" },
                    { 10005, "France" }
                });

            migrationBuilder.InsertData(
                table: "Languages",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10001, "Norwegian" },
                    { 10002, "Danish" },
                    { 10003, "Finnish" },
                    { 10004, "English" },
                    { 10005, "Swedish" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CurrentCountryID", "Name" },
                values: new object[,]
                {
                    { 10001, 10001, "Olso" },
                    { 10002, 10001, "Bergen" },
                    { 10003, 10002, "Copenhagen" },
                    { 10004, 10003, "Tornio" },
                    { 10005, 10003, "Turku" },
                    { 10006, 10004, "Vancouver" },
                    { 10007, 10005, "Paris" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CurrentCityID", "Name", "Phone" },
                values: new object[,]
                {
                    { 10008, 10001, "Nick Frost", "010-1" },
                    { 10007, 10002, "Red Forman", "010-12" },
                    { 10006, 10003, "Miike Snow", "010-123" },
                    { 10004, 10004, "Tom Delonge", "010-1234" },
                    { 10003, 10005, "Adam Buxton", "010-12345" },
                    { 10002, 10006, "Caesar Milan", "010-123456" },
                    { 10001, 10007, "Adam Bertilson", "010-1234567" },
                    { 10005, 10007, "Adam of Eternia", "010-123456777" }
                });

            migrationBuilder.InsertData(
                table: "PersonLanguages",
                columns: new[] { "PersonId", "LanguageId" },
                values: new object[,]
                {
                    { 10004, 10001 },
                    { 10003, 10001 },
                    { 10002, 10001 },
                    { 10001, 10001 },
                    { 10005, 10001 },
                    { 10005, 10002 },
                    { 10005, 10003 },
                    { 10005, 10004 },
                    { 10005, 10005 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CurrentCountryID",
                table: "Cities",
                column: "CurrentCountryID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguages_LanguageId",
                table: "PersonLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CurrentCityID",
                table: "Persons",
                column: "CurrentCityID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonLanguages");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
