using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagmentStoreService.Migrations
{
    /// <inheritdoc />
    public partial class AddColorTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "PhoneVariants");

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "PhoneVariants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Hex = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneVariants_ColorId",
                table: "PhoneVariants",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneVariants_Color_ColorId",
                table: "PhoneVariants",
                column: "ColorId",
                principalTable: "Color",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneVariants_Color_ColorId",
                table: "PhoneVariants");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropIndex(
                name: "IX_PhoneVariants_ColorId",
                table: "PhoneVariants");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "PhoneVariants");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "PhoneVariants",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
