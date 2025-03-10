using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Migrator.Migrations
{
    /// <inheritdoc />
    public partial class paymenttph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    PaymentDate = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PaymentType = table.Column<string>(type: "character varying(13)", maxLength: 13, nullable: false),
                    BankAccountNumber = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: true),
                    BankName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CardNumber = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    CardHolder = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ExpirationDate = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    PayPalEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payments");
        }
    }
}
