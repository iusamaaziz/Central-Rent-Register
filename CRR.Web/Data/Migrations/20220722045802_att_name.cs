using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CRR.Web.Data.Migrations
{
    public partial class att_name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Attachment",
                type: "nvarchar(25)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Attachment");
        }
    }
}
