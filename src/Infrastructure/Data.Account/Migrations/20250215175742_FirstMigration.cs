using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Account.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Password = table.Column<string>(type: "varchar(20)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Created_At = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Updated_At = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Deleted_At = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "account");
        }
    }
}
