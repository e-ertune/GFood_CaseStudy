using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GFood_CaseStudy.DataAccess.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_CampaignConditionProducts_Products_ProductId",
                table: "CampaignConditionProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CampaignGoalProducts_Products_ProductId",
                table: "CampaignGoalProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CampaignConditionProducts_Products_ProductId",
                table: "CampaignConditionProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_CampaignGoalProducts_Products_ProductId",
                table: "CampaignGoalProducts");
        }
    }
}
