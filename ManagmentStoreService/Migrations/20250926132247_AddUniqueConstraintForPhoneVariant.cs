using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManagmentStoreService.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueConstraintForPhoneVariant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_PhoneVariants_ModelId",
                table: "PhoneVariants");

            migrationBuilder.CreateIndex(
                name: "IX_UniquePhoneVariant",
                table: "PhoneVariants",
                columns: new[] { "ModelId", "SpecId", "ColorId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UniquePhoneVariant",
                table: "PhoneVariants");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneVariants_ModelId",
                table: "PhoneVariants",
                column: "ModelId");
        }
    }
}
