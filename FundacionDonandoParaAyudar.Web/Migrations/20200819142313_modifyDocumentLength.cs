using Microsoft.EntityFrameworkCore.Migrations;

namespace FundacionDonandoParaAyudar.Web.Migrations
{
    public partial class modifyDocumentLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DocumentType",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "AspNetUsers",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 20);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Document",
                table: "AspNetUsers",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "DocumentType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");
        }
    }
}
