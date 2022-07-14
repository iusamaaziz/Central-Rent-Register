using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRR.Web.Data.Migrations
{
    public partial class landlord_tenant_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_AspNetUsers_LandlordId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantReviews_AspNetUsers_LandlordId",
                table: "TenantReviews");

            migrationBuilder.DropColumn(
                name: "About",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PermanentAddress",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "LandlordId",
                table: "Properties",
                newName: "LandlordApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_LandlordId",
                table: "Properties",
                newName: "IX_Properties_LandlordApplicationUserId");

            migrationBuilder.CreateTable(
                name: "Landlords",
                columns: table => new
                {
                    ApplicationUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApplicationUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Landlords", x => x.ApplicationUserId);
                    table.ForeignKey(
                        name: "FK_Landlords_AspNetUsers_ApplicationUserId1",
                        column: x => x.ApplicationUserId1,
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
                name: "IX_Landlords_ApplicationUserId1",
                table: "Landlords",
                column: "ApplicationUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_ApplicationUserId1",
                table: "Tenants",
                column: "ApplicationUserId1");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Landlords_LandlordApplicationUserId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_TenantReviews_Landlords_LandlordId",
                table: "TenantReviews");

            migrationBuilder.DropTable(
                name: "Landlords");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.RenameColumn(
                name: "LandlordApplicationUserId",
                table: "Properties",
                newName: "LandlordId");

            migrationBuilder.RenameIndex(
                name: "IX_Properties_LandlordApplicationUserId",
                table: "Properties",
                newName: "IX_Properties_LandlordId");

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PermanentAddress",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_AspNetUsers_LandlordId",
                table: "Properties",
                column: "LandlordId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TenantReviews_AspNetUsers_LandlordId",
                table: "TenantReviews",
                column: "LandlordId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
