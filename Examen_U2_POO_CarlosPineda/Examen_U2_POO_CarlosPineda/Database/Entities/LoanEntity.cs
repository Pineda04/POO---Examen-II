using System;
using System.Collections.Generic;
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

        // Nombre del Cliente
        [StringLength(100)]
        [Required]
        [Column("name")]
        public string Name { get; set; }

        // Numero de Identidad
        [StringLength(20)]
        [Required]
        [Column("identity_number")]
        public Guid IdentityNumber { get; set; }

        // Monto del Prestamo
        [Required]
        [Column("loan_amount")]
        public decimal LoanAmount { get; set; }

        // Tasa de Comision
        [Required]
        [Column("commission_rate")]
        public decimal CommissionRate { get; set; }

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

        // Para la relación con el Plan de Amortización
        public virtual IEnumerable<AmortizationScheduleEntity> AmortizationSchedule { get; set; }
    }
}
