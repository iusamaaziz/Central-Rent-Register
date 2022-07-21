using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRR.Web.Data.Migrations
{
    public partial class rev_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Details",
                table: "TenantReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StayDuration",
                table: "TenantReviews",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TenantCNIC",
                table: "TenantReviews",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Attachment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    TenantReviewId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attachment_TenantReviews_TenantReviewId",
                        column: x => x.TenantReviewId,
                        principalTable: "TenantReviews",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Attachment_TenantReviewId",
                table: "Attachment",
                column: "TenantReviewId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attachment");

            migrationBuilder.DropColumn(
                name: "Details",
                table: "TenantReviews");

            migrationBuilder.DropColumn(
                name: "StayDuration",
                table: "TenantReviews");

            migrationBuilder.DropColumn(
                name: "TenantCNIC",
                table: "TenantReviews");
        }
    }
}
