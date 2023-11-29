using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP2_Entity.Migrations
{
    /// <inheritdoc />
    public partial class removeconstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DropIndex(
		   name: "IX_Customers_MembershipTypeId",
		   table: "Customers");
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.CreateIndex(
			 name: "IX_Customers_MembershipTypeId",
			 table: "Customers",
			 column: "MembershipTypeId",
			 unique: true);
		}
	}
    }

