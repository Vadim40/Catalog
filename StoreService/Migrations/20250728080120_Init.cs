using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreService.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CodecType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodecType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemsStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneSpecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StorageGb = table.Column<int>(type: "INTEGER", nullable: false),
                    RamGb = table.Column<int>(type: "INTEGER", nullable: false),
                    DisplayIn = table.Column<float>(type: "REAL", nullable: false),
                    CameraMp = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneSpecs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeadphonesSpecs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IsWireless = table.Column<bool>(type: "INTEGER", nullable: false),
                    FrequencyRangeHz = table.Column<string>(type: "TEXT", nullable: false),
                    CodecId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadphonesSpecs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadphonesSpecs_CodecType_CodecId",
                        column: x => x.CodecId,
                        principalTable: "CodecType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrackingNumber = table.Column<string>(type: "TEXT", nullable: false),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsDelivery = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PaymentAmount = table.Column<decimal>(type: "TEXT", nullable: false),
                    PaymentAmountDelivery = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HeadphonesModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadphonesModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadphonesModels_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ManufacturerId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneModels_Manufacturer_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SerialNumber = table.Column<string>(type: "TEXT", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusId = table.Column<int>(type: "INTEGER", nullable: true),
                    LocationId = table.Column<int>(type: "INTEGER", nullable: true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemsStatuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "ItemsStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Items_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HeadphonesImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HeadphonesModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadphonesImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadphonesImages_HeadphonesModels_HeadphonesModelId",
                        column: x => x.HeadphonesModelId,
                        principalTable: "HeadphonesModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeadphonesPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadphonesPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadphonesPrices_HeadphonesModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "HeadphonesModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeadphonesPrices_HeadphonesSpecs_SpecId",
                        column: x => x.SpecId,
                        principalTable: "HeadphonesSpecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhoneModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    IsMain = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublicId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhoneImages_PhoneModels_PhoneModelId",
                        column: x => x.PhoneModelId,
                        principalTable: "PhoneModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhonePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpecId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cost = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhonePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhonePrices_PhoneModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "PhoneModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhonePrices_PhoneSpecs_SpecId",
                        column: x => x.SpecId,
                        principalTable: "PhoneSpecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Headphones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: false),
                    HeadphonesSpecId = table.Column<int>(type: "INTEGER", nullable: false),
                    HeadphonesPriceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headphones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Headphones_HeadphonesModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "HeadphonesModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Headphones_HeadphonesPrices_HeadphonesPriceId",
                        column: x => x.HeadphonesPriceId,
                        principalTable: "HeadphonesPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Headphones_HeadphonesSpecs_HeadphonesSpecId",
                        column: x => x.HeadphonesSpecId,
                        principalTable: "HeadphonesSpecs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Headphones_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemId = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneSpecId = table.Column<int>(type: "INTEGER", nullable: true),
                    ModelId = table.Column<int>(type: "INTEGER", nullable: true),
                    PhonePriceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Phones_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phones_PhoneModels_ModelId",
                        column: x => x.ModelId,
                        principalTable: "PhoneModels",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Phones_PhonePrices_PhonePriceId",
                        column: x => x.PhonePriceId,
                        principalTable: "PhonePrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Phones_PhoneSpecs_PhoneSpecId",
                        column: x => x.PhoneSpecId,
                        principalTable: "PhoneSpecs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Headphones_HeadphonesPriceId",
                table: "Headphones",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Headphones_HeadphonesSpecId",
                table: "Headphones",
                column: "SpecId");

            migrationBuilder.CreateIndex(
                name: "IX_Headphones_ItemId",
                table: "Headphones",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Headphones_ModelId",
                table: "Headphones",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadphonesImages_HeadphonesModelId",
                table: "HeadphonesImages",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadphonesModels_ManufacturerId",
                table: "HeadphonesModels",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadphonesPrices_ModelId",
                table: "HeadphonesPrices",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadphonesPrices_SpecId",
                table: "HeadphonesPrices",
                column: "SpecId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadphonesSpecs_CodecId",
                table: "HeadphonesSpecs",
                column: "CodecId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CategoryId",
                table: "Items",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_LocationId",
                table: "Items",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_OrderId",
                table: "Items",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_SerialNumber",
                table: "Items",
                column: "SerialNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_StatusId",
                table: "Items",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_LocationId",
                table: "Orders",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneImages_PhoneModelId",
                table: "PhoneImages",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneModels_ManufacturerId",
                table: "PhoneModels",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_PhonePrices_ModelId",
                table: "PhonePrices",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_PhonePrices_SpecId",
                table: "PhonePrices",
                column: "SpecId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ItemId",
                table: "Phones",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_ModelId",
                table: "Phones",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhonePriceId",
                table: "Phones",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Phones_PhoneSpecId",
                table: "Phones",
                column: "SpecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Headphones");

            migrationBuilder.DropTable(
                name: "HeadphonesImages");

            migrationBuilder.DropTable(
                name: "PhoneImages");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "HeadphonesPrices");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "PhonePrices");

            migrationBuilder.DropTable(
                name: "HeadphonesModels");

            migrationBuilder.DropTable(
                name: "HeadphonesSpecs");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "ItemsStatuses");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "PhoneModels");

            migrationBuilder.DropTable(
                name: "PhoneSpecs");

            migrationBuilder.DropTable(
                name: "CodecType");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Manufacturer");
        }
    }
}
