using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRR.Web.Data.Migrations
{
    public partial class keyfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Landlords_AspNetUsers_ApplicationUserId1",
                table: "Landlords");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Landlords_LandlordApplicationUserId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantReviews_Landlords_LandlordId",
                table: "TenantReviews");

            migrationBuilder.DropIndex(
                name: "IX_TenantReviews_LandlordId",
                table: "TenantReviews");

            migrationBuilder.DropIndex(
                name: "IX_Properties_LandlordApplicationUserId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Landlords",
                table: "Landlords");

            migrationBuilder.DropIndex(
                name: "IX_Landlords_ApplicationUserId1",
                table: "Landlords");

            migrationBuilder.DropColumn(
                name: "LandlordApplicationUserId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId1",
                table: "Landlords");

            migrationBuilder.AlterColumn<string>(
                name: "LandlordId",
                table: "TenantReviews",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "LandlordId1",
                table: "TenantReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LandlordId",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Landlords",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Landlords",
                table: "Landlords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TenantReviews_LandlordId1",
                table: "TenantReviews",
                column: "LandlordId1");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LandlordId",
                table: "Properties",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_ApplicationUserId",
                table: "Landlords",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Landlords_AspNetUsers_ApplicationUserId",
                table: "Landlords",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Landlords_LandlordId",
                table: "Properties",
                column: "LandlordId",
                principalTable: "Landlords",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantReviews_Landlords_LandlordId1",
                table: "TenantReviews",
                column: "LandlordId1",
                principalTable: "Landlords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Landlords_AspNetUsers_ApplicationUserId",
                table: "Landlords");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Landlords_LandlordId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantReviews_Landlords_LandlordId1",
                table: "TenantReviews");

            migrationBuilder.DropIndex(
                name: "IX_TenantReviews_LandlordId1",
                table: "TenantReviews");

            migrationBuilder.DropIndex(
                name: "IX_Properties_LandlordId",
                table: "Properties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Landlords",
                table: "Landlords");

            migrationBuilder.DropIndex(
                name: "IX_Landlords_ApplicationUserId",
                table: "Landlords");

            migrationBuilder.DropColumn(
                name: "LandlordId1",
                table: "TenantReviews");

            migrationBuilder.DropColumn(
                name: "LandlordId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Landlords");

            migrationBuilder.AlterColumn<string>(
                name: "LandlordId",
                table: "TenantReviews",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "LandlordApplicationUserId",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId1",
                table: "Landlords",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Landlords",
                table: "Landlords",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantReviews_LandlordId",
                table: "TenantReviews",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_LandlordApplicationUserId",
                table: "Properties",
                column: "LandlordApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Landlords_ApplicationUserId1",
                table: "Landlords",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Landlords_AspNetUsers_ApplicationUserId1",
                table: "Landlords",
                column: "ApplicationUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Landlords_LandlordApplicationUserId",
                table: "Properties",
                column: "LandlordApplicationUserId",
                principalTable: "Landlords",
                principalColumn: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantReviews_Landlords_LandlordId",
                table: "TenantReviews",
                column: "LandlordId",
                principalTable: "Landlords",
                principalColumn: "ApplicationUserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
