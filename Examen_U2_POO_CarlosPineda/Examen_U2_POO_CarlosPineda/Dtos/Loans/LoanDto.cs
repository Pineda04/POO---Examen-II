namespace LoanAPI.DTOs
{
    public class LoanDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IdentityNumber { get; set; }

        public decimal LoanAmount { get; set; }

        public decimal CommissionRate { get; set; }

        public decimal InterestRate { get; set; }

        public int Term { get; set; }

        public DateTime DisbursementDate { get; set; }

        public DateTime FirstPaymentDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<AmortizationScheduleDto> AmortizationSchedule { get; set; }
    }
}
