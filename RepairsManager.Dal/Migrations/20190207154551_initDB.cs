using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepairsManager.Dal.Migrations
{
    public partial class initDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Material_party",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(maxLength: 16, nullable: true),
                    Receipt = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_party", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material_units",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 8, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material_units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_mark",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_mark", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PartyId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    UnitId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Material", x => x.Id);
                    table.ForeignKey(
                        name: "Material_fk0",
                        column: x => x.PartyId,
                        principalTable: "Material_party",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Material_fk1",
                        column: x => x.UnitId,
                        principalTable: "Material_units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle_model",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 64, nullable: false),
                    VehicleMarkId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle_model", x => x.Id);
                    table.ForeignKey(
                        name: "Vehicle_model_fk0",
                        column: x => x.VehicleMarkId,
                        principalTable: "Vehicle_mark",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleModelId = table.Column<int>(nullable: false),
                    Reg_number = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "Vehicle_fk0",
                        column: x => x.VehicleModelId,
                        principalTable: "Vehicle_model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Repair",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    RepairDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repair", x => x.Id);
                    table.ForeignKey(
                        name: "Repair_fk0",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Repair_part",
                columns: table => new
                {
                    Id = table.Column<int>(maxLength: 1, nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RepairId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Work = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "('Заменено')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repair_part", x => x.Id);
                    table.ForeignKey(
                        name: "Repair_part_fk1",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Repair_part_fk0",
                        column: x => x.RepairId,
                        principalTable: "Repair",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Material_PartyId",
                table: "Material",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_UnitId",
                table: "Material",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "UQ__Material__78A1A19D6E48A9E8",
                table: "Material_party",
                column: "Number",
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Material__737584F6720D0D0C",
                table: "Material_units",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repair_VehicleId",
                table: "Repair",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Repair_part_MaterialId",
                table: "Repair_part",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Repair_part_RepairId",
                table: "Repair_part",
                column: "RepairId");

            migrationBuilder.CreateIndex(
                name: "UQ__Vehicle__18B201F699F7FD79",
                table: "Vehicle",
                column: "Reg_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleModelId",
                table: "Vehicle",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "UQ__Vehicle___737584F68AA5465E",
                table: "Vehicle_mark",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Vehicle___737584F61CFC43C3",
                table: "Vehicle_model",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_model_VehicleMarkId",
                table: "Vehicle_model",
                column: "VehicleMarkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repair_part");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Repair");

            migrationBuilder.DropTable(
                name: "Material_party");

            migrationBuilder.DropTable(
                name: "Material_units");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Vehicle_model");

            migrationBuilder.DropTable(
                name: "Vehicle_mark");
        }
    }
}
