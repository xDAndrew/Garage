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
                name: "Commission",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<string>(maxLength: 8, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ChairmanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee_department",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_department", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employee_position",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_position", x => x.Id);
                });

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
                name: "Order_fault",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_fault", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order_status",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_status", x => x.Id);
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
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 32, nullable: false),
                    LastName = table.Column<string>(maxLength: 32, nullable: false),
                    MiddleName = table.Column<string>(maxLength: 32, nullable: false),
                    PositionId = table.Column<int>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "Employee_fk1",
                        column: x => x.DepartmentId,
                        principalTable: "Employee_department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Employee_fk0",
                        column: x => x.PositionId,
                        principalTable: "Employee_position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    Price = table.Column<decimal>(type: "decimal(18, 0)", nullable: false)
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
                name: "Commission_responsible",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CommissionId = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commission_responsible", x => x.Id);
                    table.ForeignKey(
                        name: "Commission_responsible_fk0",
                        column: x => x.CommissionId,
                        principalTable: "Commission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Commission_responsible_fk1",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Defecation_part",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MaterialId = table.Column<int>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Scope = table.Column<string>(maxLength: 16, nullable: false, defaultValueSql: "('Заменено')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defecation_part", x => x.Id);
                    table.ForeignKey(
                        name: "Defecation_part_fk0",
                        column: x => x.MaterialId,
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Depreciation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Organization = table.Column<string>(maxLength: 64, nullable: false, defaultValueSql: "('ИП \"Городская аварийная служба\"')"),
                    DepartmentId = table.Column<int>(nullable: false),
                    ApprovedId = table.Column<int>(nullable: false),
                    Number = table.Column<string>(maxLength: 8, nullable: false),
                    CommissionId = table.Column<int>(nullable: false),
                    MaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depreciation", x => x.Id);
                    table.ForeignKey(
                        name: "Depreciation_fk2",
                        column: x => x.CommissionId,
                        principalTable: "Commission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Depreciation_fk0",
                        column: x => x.DepartmentId,
                        principalTable: "Employee_department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Depreciation_fk3",
                        column: x => x.MaterialId,
                        principalTable: "Material",
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
                    Reg_number = table.Column<string>(maxLength: 16, nullable: false),
                    DriverId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                    table.ForeignKey(
                        name: "Vehicle_fk1",
                        column: x => x.DriverId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Vehicle_fk0",
                        column: x => x.VehicleModelId,
                        principalTable: "Vehicle_model",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Defecation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    PartId = table.Column<int>(nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ApprovedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defecation", x => x.Id);
                    table.ForeignKey(
                        name: "Defecation_fk2",
                        column: x => x.ApprovedId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Defecation_fk1",
                        column: x => x.PartId,
                        principalTable: "Defecation_part",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Defecation_fk0",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    VehicleId = table.Column<int>(nullable: false),
                    Speedometer = table.Column<int>(nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    StatusId = table.Column<int>(nullable: false),
                    FaultId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "Order_fk2",
                        column: x => x.FaultId,
                        principalTable: "Order_fault",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Order_fk1",
                        column: x => x.StatusId,
                        principalTable: "Order_status",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Order_fk0",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Defecation_responsible",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    defecationId = table.Column<int>(nullable: false),
                    employeeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Defecation_responsible", x => x.Id);
                    table.ForeignKey(
                        name: "Defecation_responsible_fk0",
                        column: x => x.defecationId,
                        principalTable: "Defecation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commission_responsible_CommissionId",
                table: "Commission_responsible",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Commission_responsible_EmployeeId",
                table: "Commission_responsible",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Defecation_ApprovedId",
                table: "Defecation",
                column: "ApprovedId");

            migrationBuilder.CreateIndex(
                name: "IX_Defecation_PartId",
                table: "Defecation",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_Defecation_VehicleId",
                table: "Defecation",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Defecation_part_MaterialId",
                table: "Defecation_part",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_Defecation_responsible_defecationId",
                table: "Defecation_responsible",
                column: "defecationId");

            migrationBuilder.CreateIndex(
                name: "IX_Depreciation_CommissionId",
                table: "Depreciation",
                column: "CommissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Depreciation_DepartmentId",
                table: "Depreciation",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Depreciation_MaterialId",
                table: "Depreciation",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "UQ__Deprecia__78A1A19D22E79269",
                table: "Depreciation",
                column: "Number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentId",
                table: "Employee",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionId",
                table: "Employee",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__737584F6093C4264",
                table: "Employee_department",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Employee__737584F6121BD772",
                table: "Employee_position",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Material_PartyId",
                table: "Material",
                column: "PartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Material_UnitId",
                table: "Material",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "UQ__Material__78A1A19D2DCA0491",
                table: "Material_party",
                column: "Number",
                unique: true,
                filter: "[Number] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UQ__Material__737584F6A82DA201",
                table: "Material_units",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_FaultId",
                table: "Order",
                column: "FaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StatusId",
                table: "Order",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_VehicleId",
                table: "Order",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "UQ__Order_st__737584F65815BAF6",
                table: "Order_status",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_DriverId",
                table: "Vehicle",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "UQ__Vehicle__18B201F636734836",
                table: "Vehicle",
                column: "Reg_number",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleModelId",
                table: "Vehicle",
                column: "VehicleModelId");

            migrationBuilder.CreateIndex(
                name: "UQ__Vehicle___737584F62C8CFEDB",
                table: "Vehicle_mark",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__Vehicle___737584F6D60374B5",
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
                name: "Commission_responsible");

            migrationBuilder.DropTable(
                name: "Defecation_responsible");

            migrationBuilder.DropTable(
                name: "Depreciation");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Defecation");

            migrationBuilder.DropTable(
                name: "Commission");

            migrationBuilder.DropTable(
                name: "Order_fault");

            migrationBuilder.DropTable(
                name: "Order_status");

            migrationBuilder.DropTable(
                name: "Defecation_part");

            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.DropTable(
                name: "Material");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Vehicle_model");

            migrationBuilder.DropTable(
                name: "Material_party");

            migrationBuilder.DropTable(
                name: "Material_units");

            migrationBuilder.DropTable(
                name: "Employee_department");

            migrationBuilder.DropTable(
                name: "Employee_position");

            migrationBuilder.DropTable(
                name: "Vehicle_mark");
        }
    }
}
