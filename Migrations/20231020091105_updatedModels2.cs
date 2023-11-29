using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP2_Entity.Migrations
{
    /// <inheritdoc />
    public partial class updatedModels2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "GenreId1",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MembershipTypeId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SignUpFree = table.Column<bool>(type: "bit", nullable: false),
                    DurationInMonth = table.Column<int>(type: "int", nullable: false),
                    DiscountRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CustomerId",
                table: "Movies",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId1",
                table: "Movies",
                column: "GenreId1");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                unique: true,
                filter: "[MembershipTypeId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipType",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Customers_CustomerId",
                table: "Movies",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genre_GenreId1",
                table: "Movies",
                column: "GenreId1",
                principalTable: "Genre",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Customers_CustomerId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genre_GenreId1",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropIndex(
                name: "IX_Movies_CustomerId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_GenreId1",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "GenreId1",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "Customers");
        }
    }
}
