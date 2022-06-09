using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("69ff8472-5613-4b08-ac74-cc16398709c5"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("6e30fc04-57dd-4ece-9449-2648e3a7fb8c"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("770579a3-b04e-4b30-b861-de60ba227c02"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("baa7a1ca-7884-49ec-869d-e4a3f3aa12ee"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("d02598a3-5ec4-4fc9-8f0c-75a2048f0271"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("d0bf7fb8-f8d4-491f-b9cf-d3c4c2ef41ea"));

            migrationBuilder.DeleteData(
                table: "tblCategories",
                keyColumn: "Id",
                keyValue: new Guid("a10f428b-4757-4938-83f9-596490590e0e"));

            migrationBuilder.DeleteData(
                table: "tblCategories",
                keyColumn: "Id",
                keyValue: new Guid("fe205e56-2077-43ef-9158-fe707419def6"));

            migrationBuilder.CreateTable(
                name: "tblCustomers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCustomers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("188f1bbb-c39f-403f-a55c-da1a5cb43683"), false, "Kalemler" });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("e6c88b4e-b2d2-40dc-962d-203f8304f733"), false, "Defterler" });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "Id", "CategoryId", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("0a1f227a-a4c6-4f48-8fd5-ad538184bccc"), new Guid("188f1bbb-c39f-403f-a55c-da1a5cb43683"), false, "Kursun Kalem", 62.19m, 100 },
                    { new Guid("1e6fe0d4-4531-4a97-81d9-a1537cf90cb1"), new Guid("188f1bbb-c39f-403f-a55c-da1a5cb43683"), false, "Tukenmez kalem", 18.06m, 100 },
                    { new Guid("36a3eadc-0a81-4547-a30d-3ae3b9174aed"), new Guid("188f1bbb-c39f-403f-a55c-da1a5cb43683"), false, "Dolma kalem", 122.53m, 100 },
                    { new Guid("5eb3ba7d-4ee8-4d5e-ae69-8bfbcd71c949"), new Guid("e6c88b4e-b2d2-40dc-962d-203f8304f733"), false, "Dumduz defter", 12.19m, 0 },
                    { new Guid("9e1bff21-e94b-4b72-a68f-8498f04c043e"), new Guid("e6c88b4e-b2d2-40dc-962d-203f8304f733"), false, "Çizgili Defter", 22.53m, 100 },
                    { new Guid("bbc0f781-db38-4aac-8793-530c73edc909"), new Guid("e6c88b4e-b2d2-40dc-962d-203f8304f733"), false, "Kareli Defter", 28.06m, 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblCustomers");

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("0a1f227a-a4c6-4f48-8fd5-ad538184bccc"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("1e6fe0d4-4531-4a97-81d9-a1537cf90cb1"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("36a3eadc-0a81-4547-a30d-3ae3b9174aed"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("5eb3ba7d-4ee8-4d5e-ae69-8bfbcd71c949"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("9e1bff21-e94b-4b72-a68f-8498f04c043e"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("bbc0f781-db38-4aac-8793-530c73edc909"));

            migrationBuilder.DeleteData(
                table: "tblCategories",
                keyColumn: "Id",
                keyValue: new Guid("188f1bbb-c39f-403f-a55c-da1a5cb43683"));

            migrationBuilder.DeleteData(
                table: "tblCategories",
                keyColumn: "Id",
                keyValue: new Guid("e6c88b4e-b2d2-40dc-962d-203f8304f733"));

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
        }
    }
}
