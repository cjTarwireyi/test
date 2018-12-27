using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ObtainLeads.Domain.Migrations
{
    public partial class MG1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__DebitObli__LeadI__0A9D95DB",
                table: "DebitObligation");

            migrationBuilder.DropForeignKey(
                name: "FK__LeadDeduc__Deduc__7F2BE32F",
                table: "LeadDeduction");

            migrationBuilder.DropForeignKey(
                name: "FK__MonthlyCo__LeadI__07C12930",
                table: "MonthlyCommitment");

            migrationBuilder.DropIndex(
                name: "IX_MonthlyCommitment_LeadId",
                table: "MonthlyCommitment");

            migrationBuilder.DropIndex(
                name: "IX_DebitObligation_LeadId",
                table: "DebitObligation");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "LeadDeduction");

            migrationBuilder.AddColumn<int>(
                name: "DeductionId",
                table: "LeadDeduction",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Deduction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DeductionTypeId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deduction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LeadMonthlyCommitment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadId = table.Column<int>(nullable: false),
                    MonthlyCommitmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadMonthlyCommitment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadMonthlyCommitment_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadMonthlyCommitment_MonthlyCommitment_MonthlyCommitmentId",
                        column: x => x.MonthlyCommitmentId,
                        principalTable: "MonthlyCommitment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeadObligations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LeadId = table.Column<int>(nullable: false),
                    ObligationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeadObligations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeadObligations_Lead_LeadId",
                        column: x => x.LeadId,
                        principalTable: "Lead",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LeadObligations_DebitObligation_ObligationId",
                        column: x => x.ObligationId,
                        principalTable: "DebitObligation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeadDeduction_DeductionId",
                table: "LeadDeduction",
                column: "DeductionId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadMonthlyCommitment_LeadId",
                table: "LeadMonthlyCommitment",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadMonthlyCommitment_MonthlyCommitmentId",
                table: "LeadMonthlyCommitment",
                column: "MonthlyCommitmentId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadObligations_LeadId",
                table: "LeadObligations",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_LeadObligations_ObligationId",
                table: "LeadObligations",
                column: "ObligationId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeadDeduction_Deduction_DeductionId",
                table: "LeadDeduction",
                column: "DeductionId",
                principalTable: "Deduction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LeadDeduction_DeductionType_DeductionTypeId",
                table: "LeadDeduction",
                column: "DeductionTypeId",
                principalTable: "DeductionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeadDeduction_Deduction_DeductionId",
                table: "LeadDeduction");

            migrationBuilder.DropForeignKey(
                name: "FK_LeadDeduction_DeductionType_DeductionTypeId",
                table: "LeadDeduction");

            migrationBuilder.DropTable(
                name: "Deduction");

            migrationBuilder.DropTable(
                name: "LeadMonthlyCommitment");

            migrationBuilder.DropTable(
                name: "LeadObligations");

            migrationBuilder.DropIndex(
                name: "IX_LeadDeduction_DeductionId",
                table: "LeadDeduction");

            migrationBuilder.DropColumn(
                name: "DeductionId",
                table: "LeadDeduction");

            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "LeadDeduction",
                type: "numeric(18, 0)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyCommitment_LeadId",
                table: "MonthlyCommitment",
                column: "LeadId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitObligation_LeadId",
                table: "DebitObligation",
                column: "LeadId");

            migrationBuilder.AddForeignKey(
                name: "FK__DebitObli__LeadI__0A9D95DB",
                table: "DebitObligation",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__LeadDeduc__Deduc__7F2BE32F",
                table: "LeadDeduction",
                column: "DeductionTypeId",
                principalTable: "DeductionType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK__MonthlyCo__LeadI__07C12930",
                table: "MonthlyCommitment",
                column: "LeadId",
                principalTable: "Lead",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
