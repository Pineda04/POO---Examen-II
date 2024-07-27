using System.ComponentModel.DataAnnotations;

namespace LoanAPI.Dtos
{
    public class AmortizationScheduleCreateDto
    {
        // Identificador del préstamo asociado
        [Required(ErrorMessage = "El {0} es requerido.")]
        public Guid LoanId { get; set; }

        // Fecha del pago
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime PaymentDate { get; set; }

        // Monto total de la cuota
        [Required(ErrorMessage = "El {0} es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El {0} debe ser mayor que cero.")]
        public decimal InstallmentAmount { get; set; }

        // Capital pagado
        [Required(ErrorMessage = "El {0} es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El {0} debe ser mayor que cero.")]
        public decimal PrincipalPaid { get; set; }

        // Interés pagado
        [Required(ErrorMessage = "El {0} es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El {0} debe ser mayor que cero.")]
        public decimal InterestPaid { get; set; }

        // Saldo restante del préstamo
        [Required(ErrorMessage = "El {0} es requerido.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El {0} debe ser mayor que cero.")]
        public decimal RemainingBalance { get; set; }
    }
}
