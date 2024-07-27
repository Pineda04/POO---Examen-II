namespace LoanAPI.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string IdentityNumber { get; set; }

        public DateTime CreatedAt { get; set; }

        public IEnumerable<LoanDto> Loans { get; set; }
    }
}
