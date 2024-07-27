using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Database.Entities
{
    [Table("loans", Schema = "dbo")]
    public class LoanEntity
    {
        // Id
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        // Id del Cliente
        [Required]
        [ForeignKey("CustomerEntity")]
        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        // Monto del Prestamo
        [Required]
        [Column("loan_amount")]
        public decimal LoanAmount { get; set; }

        // Tasa de Interes
        [Required]
        [Column("interest_rate")]
        public decimal InterestRate { get; set; }

        // Plazo (meses)
        [Required]
        [Column("term")]
        public int Term { get; set; }

        // Fecha de Desembolso
        [Required]
        [Column("disbursement_date")]
        public DateTime DisbursementDate { get; set; }

        // Fecha del Primer Pago
        [Required]
        [Column("first_payment_date")]
        public DateTime FirstPaymentDate { get; set; }

        // Fecha de Creación
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        public string IdentityNumber { get; set; }

        // Relación con el Cliente
        public virtual CustomerEntity Customer { get; set; }

        // Relación con el Plan de Amortización
        public virtual IEnumerable<AmortizationScheduleEntity> AmortizationSchedule { get; set; }
    }
}
