using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen_U2_POO_CarlosPineda.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    identity_number = table.Column<Guid>(type: "uniqueidentifier", maxLength: 20, nullable: false),
                    loan_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    commission_rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    interest_rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    term = table.Column<int>(type: "int", nullable: false),
                    disbursement_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    first_payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.id);
                    table.ForeignKey(
                        name: "FK_loans_customers_CustomerEntityId",
                        column: x => x.CustomerEntityId,
                        principalTable: "customers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "amortization_schedule",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loan_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    installment_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    principal_paid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    interest_paid = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    remaining_balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_amortization_schedule", x => x.id);
                    table.ForeignKey(
                        name: "FK_amortization_schedule_loans_loan_id",
                        column: x => x.loan_id,
                        principalSchema: "dbo",
                        principalTable: "loans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_amortization_schedule_loan_id",
                schema: "dbo",
                table: "amortization_schedule",
                column: "loan_id");

            migrationBuilder.CreateIndex(
                name: "IX_loans_CustomerEntityId",
                schema: "dbo",
                table: "loans",
                column: "CustomerEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "amortization_schedule",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "loans",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "customers");
        }
    }
}
