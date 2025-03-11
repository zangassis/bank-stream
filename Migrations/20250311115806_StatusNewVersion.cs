using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankStream.Migrations
{
    /// <inheritdoc />
    public partial class StatusNewVersion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusEnum",
                table: "TransactionStatus",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusEnum",
                table: "TransactionStatus");
        }
    }
}
