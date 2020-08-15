using Microsoft.EntityFrameworkCore.Migrations;

namespace FundacionDonandoParaAyudar.Web.Migrations
{
    public partial class FieldDocumentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "SendMessages",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "SendMessages");

            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "AspNetUsers");
        }
    }
}
