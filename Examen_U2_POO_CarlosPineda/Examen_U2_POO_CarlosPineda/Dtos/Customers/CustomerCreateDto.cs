using System.ComponentModel.DataAnnotations;

namespace LoanAPI.DTOs
{
    public class CustomerCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string IdentityNumber { get; set; }
    }
}
