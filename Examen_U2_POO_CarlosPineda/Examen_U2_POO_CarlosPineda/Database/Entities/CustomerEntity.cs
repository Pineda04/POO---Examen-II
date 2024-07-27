using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanAPI.Database.Entities
{
    [Table("customers", Schema = "dbo")]
    public class CustomerEntity
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
        public string IdentityNumber { get; set; }

        // Fecha de Creación
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        // Relación con los Prestamos
        public virtual IEnumerable<LoanEntity> Loans { get; set; }
    }
}
