using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ObtainLeads.Domain.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeductionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeductionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncomeType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncomeType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lead",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Sent = table.Column<string>(unicode: false, maxLength: 1, nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lead", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DebitObligation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadId = table.Column<int>(nullable: false),
                    DebtCommitment = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    NameOfCreditor = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TotalAmountOutstanding = table.Column<decimal>(type: "numeric(18, 0)", nullable: true),
                    MonthlyCommitment = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitObligation", x => x.Id);
                    table.ForeignKey(
                        name: "FK__DebitObli__LeadI__0A9D95DB",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeclarationByConsumer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadId = table.Column<int>(nullable: false),
                    SignedAt = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Signed = table.Column<string>(unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeclarationByConsumer", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Declarati__LeadI__0D7A0286",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadsId = table.Column<int>(nullable: true),
                    EmployerName = table.Column<string>(unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employer", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Employer__LeadsI__6383C8BA",
                        column: x => x.LeadsId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadsId = table.Column<int>(nullable: false),
                    AddressTypeId = table.Column<int>(nullable: false),
                    Line1 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Line2 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    zip = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK__LeadAddre__Addre__73BA3083",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LeadAddre__Leads__72C60C4A",
                        column: x => x.LeadsId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadContactDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadsId = table.Column<int>(nullable: false),
                    HomeNo = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    CellNo = table.Column<string>(unicode: false, maxLength: 20, nullable: false),
                    Email = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadContactDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK__LeadConta__Leads__6FE99F9F",
                        column: x => x.LeadsId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadDeduction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadId = table.Column<int>(nullable: true),
                    DeductionTypeId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadDeduction", x => x.Id);
                    table.ForeignKey(
                        name: "FK__LeadDeduc__Deduc__7F2BE32F",
                        column: x => x.DeductionTypeId,
                        principalTable: "DeductionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LeadDeduc__LeadI__7E37BEF6",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeadIncome",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadId = table.Column<int>(nullable: true),
                    IncomeTypeId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(type: "numeric(18, 0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK__LeadIncom__Incom__04E4BC85",
                        column: x => x.IncomeTypeId,
                        principalTable: "IncomeType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__LeadIncom__LeadI__03F0984C",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MonthlyCommitment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadId = table.Column<int>(nullable: false),
                    Commitment = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    MonthlyExpense = table.Column<decimal>(type: "numeric(18, 0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyCommitment", x => x.Id);
                    table.ForeignKey(
                        name: "FK__MonthlyCo__LeadI__07C12930",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployerAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployerId = table.Column<int>(nullable: false),
                    AddressTypeId = table.Column<int>(nullable: false),
                    Line1 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Line2 = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    zip = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK__EmployerA__Addre__6754599E",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__EmployerA__Emplo__66603565",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployerContactDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmployerId = table.Column<int>(nullable: true),
                    WorkNo = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployerContactDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK__EmployerC__Emplo__6A30C649",
                        column: x => x.EmployerId,
                        principalTable: "Employer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DebitObligation_LeadId",
                table: "DebitObligation",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationByConsumer_LeadId",
                table: "DeclarationByConsumer",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Employer_LeadsId",
                table: "Employer",
                column: "LeadsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerAddress_AddressTypeId",
                table: "EmployerAddress",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerAddress_EmployerId",
                table: "EmployerAddress",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployerContactDetail_EmployerId",
                table: "EmployerContactDetail",
                column: "EmployerId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAddress_AddressTypeId",
                table: "LeadAddress",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadAddress_LeadsId",
                table: "LeadAddress",
                column: "LeadsId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadContactDetail_LeadsId",
                table: "LeadContactDetail",
                column: "LeadsId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadDeduction_DeductionTypeId",
                table: "LeadDeduction",
                column: "DeductionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadDeduction_LeadId",
                table: "LeadDeduction",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadIncome_IncomeTypeId",
                table: "LeadIncome",
                column: "IncomeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadIncome_LeadId",
                table: "LeadIncome",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCommitment_LeadId",
                table: "MonthlyCommitment",
                column: "LeadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DebitObligation");

            migrationBuilder.DropTable(
                name: "DeclarationByConsumer");

            migrationBuilder.DropTable(
                name: "EmployerAddress");

            migrationBuilder.DropTable(
                name: "EmployerContactDetail");

            migrationBuilder.DropTable(
                name: "LeadAddress");

            migrationBuilder.DropTable(
                name: "LeadContactDetail");

            migrationBuilder.DropTable(
                name: "LeadDeduction");

            migrationBuilder.DropTable(
                name: "LeadIncome");

            migrationBuilder.DropTable(
                name: "MonthlyCommitment");

            migrationBuilder.DropTable(
                name: "Employer");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "DeductionType");

            migrationBuilder.DropTable(
                name: "IncomeType");

            migrationBuilder.DropTable(
                name: "Lead");
        }
    }
}
