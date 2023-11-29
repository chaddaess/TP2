using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP2_Entity.Migrations
{
    /// <inheritdoc />
    public partial class updateTableMovie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Movies_CustomerId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipType",
                table: "MembershipType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genre",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "MembershipType",
                newName: "MembershipTypes");

            migrationBuilder.RenameTable(
                name: "Genre",
                newName: "Genres");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipTypes",
                table: "MembershipTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genres",
                table: "Genres",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CustomerMovie",
                columns: table => new
                {
                    CustomersId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMovie", x => new { x.CustomersId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_CustomerMovie_Customers_CustomersId",
                        column: x => x.CustomersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMovie_MoviesId",
                table: "CustomerMovie",
                column: "MoviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId1",
                table: "Movies",
                column: "GenreId1",
                principalTable: "Genres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId1",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "CustomerMovie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipTypes",
                table: "MembershipTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Genres",
                table: "Genres");

            migrationBuilder.RenameTable(
                name: "MembershipTypes",
                newName: "MembershipType");

            migrationBuilder.RenameTable(
                name: "Genres",
                newName: "Genre");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Movies",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipType",
                table: "MembershipType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Genre",
                table: "Genre",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_CustomerId",
                table: "Movies",
                column: "CustomerId");

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
    }
}
