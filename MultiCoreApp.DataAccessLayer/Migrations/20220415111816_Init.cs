using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tblProducts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tblProducts_tblCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tblCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("a10f428b-4757-4938-83f9-596490590e0e"), false, "Kalemler" });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("fe205e56-2077-43ef-9158-fe707419def6"), false, "Defterler" });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "Id", "CategoryId", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("69ff8472-5613-4b08-ac74-cc16398709c5"), new Guid("fe205e56-2077-43ef-9158-fe707419def6"), false, "Dumduz defter", 12.19m, 0 },
                    { new Guid("6e30fc04-57dd-4ece-9449-2648e3a7fb8c"), new Guid("fe205e56-2077-43ef-9158-fe707419def6"), false, "Çizgili Defter", 22.53m, 100 },
                    { new Guid("770579a3-b04e-4b30-b861-de60ba227c02"), new Guid("a10f428b-4757-4938-83f9-596490590e0e"), false, "Kursun Kalem", 62.19m, 100 },
                    { new Guid("baa7a1ca-7884-49ec-869d-e4a3f3aa12ee"), new Guid("a10f428b-4757-4938-83f9-596490590e0e"), false, "Dolma kalem", 122.53m, 100 },
                    { new Guid("d02598a3-5ec4-4fc9-8f0c-75a2048f0271"), new Guid("a10f428b-4757-4938-83f9-596490590e0e"), false, "Tukenmez kalem", 18.06m, 100 },
                    { new Guid("d0bf7fb8-f8d4-491f-b9cf-d3c4c2ef41ea"), new Guid("fe205e56-2077-43ef-9158-fe707419def6"), false, "Kareli Defter", 28.06m, 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblProducts_CategoryId",
                table: "tblProducts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblProducts");

            migrationBuilder.DropTable(
                name: "tblCategories");
        }
    }
}
