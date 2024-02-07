using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManager.Infraestructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTableLoans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BookId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "bookId",
                table: "Books",
                column: "Id",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "userId",
                table: "Users",
                column: "Id",
                principalTable: "Loans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "bookId",
                table: "Books");

            migrationBuilder.DropForeignKey(
                name: "userId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Loans");
        }
    }
}
