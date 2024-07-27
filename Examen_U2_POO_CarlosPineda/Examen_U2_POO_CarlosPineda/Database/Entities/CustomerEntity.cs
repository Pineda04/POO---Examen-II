using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Database.Entities
{
    [Table("customers")]
    public class CustomerEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(15)]
        public string PhoneNumber { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        public IEnumerable<LoanEntity> Loans { get; set; }
    }
}