using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Database.Entities
{
    [Table("amortization_schedule", Schema = "dbo")]
    public class AmortizationScheduleEntity
    {
        // Id del cronograma de amortizacion
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        // Id del prestamo asociado
        [ForeignKey("Loan")]
        [Column("loan_id")]
        public Guid LoanId { get; set; }

        // Fecha del pago
        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }

        // Monto de la cuota
        [Column("installment_amount")]
        public decimal InstallmentAmount { get; set; }

        // Capital pagado
        [Column("principal_paid")]
        public decimal PrincipalPaid { get; set; }

        // Interes pagado
        [Column("interest_paid")]
        public decimal InterestPaid { get; set; }

        // Saldo restante
        [Column("remaining_balance")]
        public decimal RemainingBalance { get; set; }

        // Relación con el prestamo
        public virtual LoanEntity Loan { get; set; }
    }
}
