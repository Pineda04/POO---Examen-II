using System.ComponentModel.DataAnnotations;

namespace LoanAPI.DTOs
{
    public class LoanCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string IdentityNumber { get; set; }

        [Required]
        public decimal LoanAmount { get; set; }

        [Required]
        public decimal CommissionRate { get; set; }

        [Required]
        public decimal InterestRate { get; set; }

        [Required]
        public int Term { get; set; }

        [Required]
        public DateTime DisbursementDate { get; set; }

        [Required]
        public DateTime FirstPaymentDate { get; set; }
    }
}
