using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BankConsoleApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    account_number = table.Column<uint>(type: "int unsigned", nullable: false),
                    owner = table.Column<string>(type: "varchar(45)", maxLength: 45, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creation_date = table.Column<DateOnly>(type: "date", nullable: false),
                    account_type = table.Column<string>(type: "varchar(7)", maxLength: 7, nullable: false, collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    balance = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.account_number);
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    transaction_number = table.Column<int>(type: "int", nullable: false),
                    mount = table.Column<float>(type: "float", nullable: false),
                    creation_date = table.Column<DateOnly>(type: "date", nullable: false),
                    description = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, defaultValueSql: "'N/A'", collation: "utf8mb4_0900_ai_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    account_number = table.Column<uint>(type: "int unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PRIMARY", x => x.transaction_number);
                    table.ForeignKey(
                        name: "fk_accountnumber",
                        column: x => x.account_number,
                        principalTable: "account",
                        principalColumn: "account_number");
                })
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "fk_accountnumber_idx",
                table: "transaction",
                column: "account_number");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "account");
        }
    }
}
