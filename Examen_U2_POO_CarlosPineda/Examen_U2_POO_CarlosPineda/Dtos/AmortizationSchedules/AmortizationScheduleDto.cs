namespace LoanAPI.DTOs
{
    public class AmortizationScheduleDto
    {
        public int InstallmentNumber { get; set; }

        public DateTime PaymentDate { get; set; }

        public int Days { get; set; }

        public decimal Interest { get; set; }

        public decimal Principal { get; set; }

        public decimal LevelPaymentWithoutSVSD { get; set; }

        public decimal ExtraordinaryPayment { get; set; }

        public decimal LevelPaymentWithSVSD { get; set; }

        public decimal PrincipalBalance { get; set; }
    }
}
