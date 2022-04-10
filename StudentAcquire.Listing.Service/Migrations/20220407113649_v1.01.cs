using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentAcquire.Listing.Service.Migrations
{
    public partial class v101 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seller_Listings_ListingId",
                table: "Seller");

            migrationBuilder.DropIndex(
                name: "IX_Seller_ListingId",
                table: "Seller");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "Seller");

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Listings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Listings_SellerId",
                table: "Listings",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Seller_SellerId",
                table: "Listings",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Seller_SellerId",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_SellerId",
                table: "Listings");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Listings");

            migrationBuilder.AddColumn<int>(
                name: "ListingId",
                table: "Seller",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seller_ListingId",
                table: "Seller",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seller_Listings_ListingId",
                table: "Seller",
                column: "ListingId",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
