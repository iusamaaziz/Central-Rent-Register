using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRR.Web.Data.Migrations
{
    public partial class ignore_overview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_TenantReviews_TenantReviewId",
                table: "Attachment");

            migrationBuilder.AlterColumn<int>(
                name: "TenantReviewId",
                table: "Attachment",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_TenantReviews_TenantReviewId",
                table: "Attachment",
                column: "TenantReviewId",
                principalTable: "TenantReviews",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Attachment_TenantReviews_TenantReviewId",
                table: "Attachment");

            migrationBuilder.AlterColumn<int>(
                name: "TenantReviewId",
                table: "Attachment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Attachment_TenantReviews_TenantReviewId",
                table: "Attachment",
                column: "TenantReviewId",
                principalTable: "TenantReviews",
                principalColumn: "Id");
        }
    }
}
