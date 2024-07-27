namespace LoanAPI.Dtos
{
    public class AmortizationScheduleDto
    {
        public Guid Id { get; set; }

        public Guid LoanId { get; set; }

        public DateTime PaymentDate { get; set; }

        public decimal InstallmentAmount { get; set; }

        public decimal PrincipalPaid { get; set; }

        public decimal InterestPaid { get; set; }

        public decimal RemainingBalance { get; set; }
    }
}