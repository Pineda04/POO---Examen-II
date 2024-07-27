using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Database.Entities
{
    [Table("amortization_schedule", Schema = "dbo")]
    public class AmortizationScheduleEntity
    {
        // Id
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        // Id del Prestamo
        [Required]
        [ForeignKey("LoanEntity")]
        [Column("loan_id")]
        public Guid LoanId { get; set; }

        // Numero de Cuota
        [Required]
        [Column("installment_number")]
        public int InstallmentNumber { get; set; }

        // Fecha de Pago
        [Required]
        [Column("payment_date")]
        public DateTime PaymentDate { get; set; }

        // Dias
        [Required]
        [Column("days")]
        public int Days { get; set; }

        // Interes
        [Required]
        [Column("interest")]
        public decimal Interest { get; set; }

        // Principal (Abono)
        [Required]
        [Column("principal")]
        public decimal Principal { get; set; }

        // Otros Cargos SVSD
        [Required]
        [Column("other_charges_svds")]
        public decimal OtherChargesSVSD { get; set; }

        // Cuota (sin SVSD)
        [Required]
        [Column("level_payment_without_svds")]
        public decimal LevelPaymentWithoutSVSD { get; set; }

        // Abono Extraordinario
        [Required]
        [Column("extraordinary_payment")]
        public decimal ExtraordinaryPayment { get; set; }

        // Cuota (Con SVSD)
        [Required]
        [Column("level_payment_with_svds")]
        public decimal LevelPaymentWithSVSD { get; set; }

        // Saldo Principal
        [Required]
        [Column("principal_balance")]
        public decimal PrincipalBalance { get; set; }

        // Fecha de Creacion
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        // Relación con el Prestamo
        public virtual LoanEntity Loan { get; set; }
    }
}
