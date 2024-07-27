using System.ComponentModel.DataAnnotations;

namespace LoanAPI.Dtos.Loans
{
    public class LoanCreateDto
    {
        // Nombre del Cliente
        [Display(Name = "Nombre del Cliente")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public string Name { get; set; }

        // Número de Identidad
        [Display(Name = "Número de Identidad")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(20, ErrorMessage = "El {0} no puede exceder los {1} caracteres.")]
        public string IdentityNumber { get; set; }

        // Monto del Préstamo
        [Display(Name = "Monto del Préstamo")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public decimal LoanAmount { get; set; }

        // Tasa de Comisión
        [Display(Name = "Tasa de Comisión (%)")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public decimal CommissionRate { get; set; }

        // Tasa de Interés
        [Display(Name = "Tasa de Interés (%)")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public decimal InterestRate { get; set; }

        // Plazo (meses)
        [Display(Name = "Plazo (meses)")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        public int Term { get; set; }

        // Fecha de Desembolso
        [Display(Name = "Fecha de Desembolso")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime DisbursementDate { get; set; }

        // Fecha del Primer Pago
        [Display(Name = "Fecha del Primer Pago")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime FirstPaymentDate { get; set; }
    }
}
