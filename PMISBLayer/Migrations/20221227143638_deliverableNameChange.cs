using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMISBLayer.Migrations
{
    public partial class deliverableNameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTerms_Delivrables_DelivrableId",
                table: "PaymentTerms");

            migrationBuilder.DropTable(
                name: "Delivrables");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTerms_DelivrableId",
                table: "PaymentTerms");

            migrationBuilder.DropColumn(
                name: "DelivrableId",
                table: "PaymentTerms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProjectPhases",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProjectPhases",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<int>(
                name: "DeliverableId",
                table: "PaymentTerms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InvoiceDate",
                table: "Invoices",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateTable(
                name: "Deliverables",
                columns: table => new
                {
                    DeliverableId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliverableName = table.Column<string>(nullable: true),
                    DeliverableDescription = table.Column<string>(nullable: true),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ProjectPhaseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliverables", x => x.DeliverableId);
                    table.ForeignKey(
                        name: "FK_Deliverables_ProjectPhases_ProjectPhaseID",
                        column: x => x.ProjectPhaseID,
                        principalTable: "ProjectPhases",
                        principalColumn: "ProjectPhaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTerms_DeliverableId",
                table: "PaymentTerms",
                column: "DeliverableId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliverables_ProjectPhaseID",
                table: "Deliverables",
                column: "ProjectPhaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTerms_Deliverables_DeliverableId",
                table: "PaymentTerms",
                column: "DeliverableId",
                principalTable: "Deliverables",
                principalColumn: "DeliverableId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTerms_Deliverables_DeliverableId",
                table: "PaymentTerms");

            migrationBuilder.DropTable(
                name: "Deliverables");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTerms_DeliverableId",
                table: "PaymentTerms");

            migrationBuilder.DropColumn(
                name: "DeliverableId",
                table: "PaymentTerms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProjectPhases",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProjectPhases",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddColumn<int>(
                name: "DelivrableId",
                table: "PaymentTerms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "InvoiceDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.CreateTable(
                name: "Delivrables",
                columns: table => new
                {
                    DelivrableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DelivrableDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DelivrableName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectPhaseID = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delivrables", x => x.DelivrableId);
                    table.ForeignKey(
                        name: "FK_Delivrables_ProjectPhases_ProjectPhaseID",
                        column: x => x.ProjectPhaseID,
                        principalTable: "ProjectPhases",
                        principalColumn: "ProjectPhaseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTerms_DelivrableId",
                table: "PaymentTerms",
                column: "DelivrableId");

            migrationBuilder.CreateIndex(
                name: "IX_Delivrables_ProjectPhaseID",
                table: "Delivrables",
                column: "ProjectPhaseID");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTerms_Delivrables_DelivrableId",
                table: "PaymentTerms",
                column: "DelivrableId",
                principalTable: "Delivrables",
                principalColumn: "DelivrableId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
