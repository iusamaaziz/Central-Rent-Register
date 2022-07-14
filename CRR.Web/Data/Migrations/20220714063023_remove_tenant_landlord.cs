using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRR.Web.Data.Migrations
{
    public partial class remove_tenant_landlord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Landlords_LandlordId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantReviews_Landlords_LandlordId1",
                table: "TenantReviews");

            migrationBuilder.DropTable(
                name: "Landlords");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_TenantReviews_LandlordId1",
                table: "TenantReviews");

            migrationBuilder.DropIndex(
                name: "IX_Properties_LandlordId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "LandlordId",
                table: "TenantReviews");

            migrationBuilder.DropColumn(
                name: "LandlordId1",
                table: "TenantReviews");

            migrationBuilder.DropColumn(
                name: "LandlordId",
                table: "Properties");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "TenantReviews",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "Properties",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TenantReviews_ApplicationUserId",
                table: "TenantReviews",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_ApplicationUserId",
                table: "Properties",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_AspNetUsers_ApplicationUserId",
                table: "Properties",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantReviews_AspNetUsers_ApplicationUserId",
                table: "TenantReviews",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_AspNetUsers_ApplicationUserId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantReviews_AspNetUsers_ApplicationUserId",
                table: "TenantReviews");

            migrationBuilder.DropIndex(
                name: "IX_TenantReviews_ApplicationUserId",
                table: "TenantReviews");

            migrationBuilder.DropIndex(
                name: "IX_Properties_ApplicationUserId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "TenantReviews");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "About",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "LandlordId",
                table: "TenantReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Landlords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Landlords_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.ApplicationUserId);
                    table.ForeignKey(
                        name: "FK_Tenants_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApplicationUserId1",
                table: "Tenants",
                column: "ApplicationUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Landlords_LandlordId",
                table: "Properties",
                column: "LandlordId",
                principalTable: "Landlords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TenantReviews_Landlords_LandlordId1",
                table: "TenantReviews",
                column: "LandlordId1",
                principalTable: "Landlords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
