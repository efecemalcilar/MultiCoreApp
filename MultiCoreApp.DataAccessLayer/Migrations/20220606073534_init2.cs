using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MultiCoreApp.DataAccessLayer.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenEndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("060bfbf9-ebbe-4bbb-8559-db1276678a72"), false, "Kalemler" });

            migrationBuilder.InsertData(
                table: "tblCategories",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { new Guid("bab90f9b-a655-4fe9-9a8c-a1b5d73088a2"), false, "Defterler" });

            migrationBuilder.InsertData(
                table: "tblProducts",
                columns: new[] { "Id", "CategoryId", "IsDeleted", "Name", "Price", "Stock" },
                values: new object[,]
                {
                    { new Guid("1a32af65-3614-48d9-9212-f1f3069d2305"), new Guid("060bfbf9-ebbe-4bbb-8559-db1276678a72"), false, "Kursun Kalem", 62.19m, 100 },
                    { new Guid("475eb5dc-1abb-4888-a230-ccd3ae2054f2"), new Guid("bab90f9b-a655-4fe9-9a8c-a1b5d73088a2"), false, "Çizgili Defter", 22.53m, 100 },
                    { new Guid("47c50e32-410e-4801-bbc5-f239ebf02959"), new Guid("060bfbf9-ebbe-4bbb-8559-db1276678a72"), false, "Dolma kalem", 122.53m, 100 },
                    { new Guid("49e992b1-9cd4-42a5-8eb2-6b6bea968249"), new Guid("bab90f9b-a655-4fe9-9a8c-a1b5d73088a2"), false, "Dumduz defter", 12.19m, 0 },
                    { new Guid("9b59052a-31cd-4095-a16b-0bfcbd63a9e0"), new Guid("bab90f9b-a655-4fe9-9a8c-a1b5d73088a2"), false, "Kareli Defter", 28.06m, 100 },
                    { new Guid("fe86a00b-884f-4ca0-ae27-15d7879e2e17"), new Guid("060bfbf9-ebbe-4bbb-8559-db1276678a72"), false, "Tukenmez kalem", 18.06m, 100 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("1a32af65-3614-48d9-9212-f1f3069d2305"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("475eb5dc-1abb-4888-a230-ccd3ae2054f2"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("47c50e32-410e-4801-bbc5-f239ebf02959"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("49e992b1-9cd4-42a5-8eb2-6b6bea968249"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("9b59052a-31cd-4095-a16b-0bfcbd63a9e0"));

            migrationBuilder.DeleteData(
                table: "tblProducts",
                keyColumn: "Id",
                keyValue: new Guid("fe86a00b-884f-4ca0-ae27-15d7879e2e17"));

            migrationBuilder.DeleteData(
                table: "tblCategories",
                keyColumn: "Id",
                keyValue: new Guid("060bfbf9-ebbe-4bbb-8559-db1276678a72"));

            migrationBuilder.DeleteData(
                table: "tblCategories",
                keyColumn: "Id",
                keyValue: new Guid("bab90f9b-a655-4fe9-9a8c-a1b5d73088a2"));

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
    }
}
