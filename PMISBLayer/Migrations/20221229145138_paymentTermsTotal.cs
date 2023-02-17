using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMISBLayer.Migrations
{
    public partial class paymentTermsTotal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliverables_ProjectPhases_ProjectPhaseID",
                table: "Deliverables");

            migrationBuilder.RenameColumn(
                name: "ProjectPhaseID",
                table: "Deliverables",
                newName: "ProjectPhaseId");

            migrationBuilder.RenameIndex(
                name: "IX_Deliverables_ProjectPhaseID",
                table: "Deliverables",
                newName: "IX_Deliverables_ProjectPhaseId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AddColumn<decimal>(
                name: "PaymentTermsTotal",
                table: "Projects",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProjectPhases",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProjectPhases",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "PaymentTermTitle",
                table: "PaymentTerms",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Deliverables",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Deliverables",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "DeliverableName",
                table: "Deliverables",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DeliverableDescription",
                table: "Deliverables",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Deliverables_ProjectPhases_ProjectPhaseId",
                table: "Deliverables",
                column: "ProjectPhaseId",
                principalTable: "ProjectPhases",
                principalColumn: "ProjectPhaseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deliverables_ProjectPhases_ProjectPhaseId",
                table: "Deliverables");

            migrationBuilder.DropColumn(
                name: "PaymentTermsTotal",
                table: "Projects");

            migrationBuilder.RenameColumn(
                name: "ProjectPhaseId",
                table: "Deliverables",
                newName: "ProjectPhaseID");

            migrationBuilder.RenameIndex(
                name: "IX_Deliverables_ProjectPhaseId",
                table: "Deliverables",
                newName: "IX_Deliverables_ProjectPhaseID");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Projects",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "ProjectPhases",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "ProjectPhases",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "PaymentTermTitle",
                table: "PaymentTerms",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "Deliverables",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "Deliverables",
                type: "Date",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "DeliverableName",
                table: "Deliverables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DeliverableDescription",
                table: "Deliverables",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Deliverables_ProjectPhases_ProjectPhaseID",
                table: "Deliverables",
                column: "ProjectPhaseID",
                principalTable: "ProjectPhases",
                principalColumn: "ProjectPhaseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
