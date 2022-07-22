using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRR.Web.Data.Migrations
{
    public partial class add_rating_ov : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "RatingOverview",
                table: "TenantReviews",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RatingOverview",
                table: "TenantReviews");
        }
    }
}
