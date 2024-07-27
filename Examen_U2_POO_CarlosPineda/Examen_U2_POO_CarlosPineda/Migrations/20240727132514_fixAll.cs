using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen_U2_POO_CarlosPineda.Migrations
{
    /// <inheritdoc />
    public partial class fixAll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "customers",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    identity_number = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "loans",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    customer_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loan_amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    interest_rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    term = table.Column<int>(type: "int", nullable: false),
                    disbursement_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    first_payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_loans", x => x.id);
                    table.ForeignKey(
                        name: "FK_loans_customers_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "dbo",
                        principalTable: "customers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "amortization_schedule",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    loan_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    installment_number = table.Column<int>(type: "int", nullable: false),
                    payment_date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false),
                    interest = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    principal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    other_charges_svds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    level_payment_without_svds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    extraordinary_payment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    level_payment_with_svds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    principal_balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false)
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
                name: "IX_loans_customer_id",
                schema: "dbo",
                table: "loans",
                column: "customer_id");
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
                name: "customers",
                schema: "dbo");
        }
    }
}
