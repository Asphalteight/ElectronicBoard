using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Board.Host.Migrator.Migrations
{
    /// <inheritdoc />
    public partial class Files_Images : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Advertisements",
                type: "character varying(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Accounts",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Content = table.Column<byte[]>(type: "bytea", nullable: false),
                    ContentType = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    Length = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageKits",
                columns: table => new
                {
                    AdvertisementId = table.Column<int>(type: "integer", nullable: false),
                    FirstImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    SecondImageId = table.Column<Guid>(type: "uuid", nullable: true),
                    ThirdImageId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageKits", x => x.AdvertisementId);
                    table.ForeignKey(
                        name: "FK_ImageKits_Advertisements_AdvertisementId",
                        column: x => x.AdvertisementId,
                        principalTable: "Advertisements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "ImageKits");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Advertisements");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Accounts");
        }
    }
}
