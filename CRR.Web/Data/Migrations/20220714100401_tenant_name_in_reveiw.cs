using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRR.Web.Data.Migrations
{
    public partial class tenant_name_in_reveiw : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TenantName",
                table: "TenantReviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantName",
                table: "TenantReviews");
        }
    }
}
