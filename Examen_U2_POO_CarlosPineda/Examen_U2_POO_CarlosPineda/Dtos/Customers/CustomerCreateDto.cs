using System;
using System.ComponentModel.DataAnnotations;

namespace LoanAPI.Dtos.Customers
{
    public class CustomerCreateDto
    {
        // Nombre del cliente
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(50, ErrorMessage = "El {0} no puede exceder los {1} caracteres.")]
        public string FirstName { get; set; }

        // Apellido del cliente
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [StringLength(50, ErrorMessage = "El {0} no puede exceder los {1} caracteres.")]
        public string LastName { get; set; }

        // Correo electronico del cliente
        [Display(Name = "Correo Electrónico")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [EmailAddress(ErrorMessage = "El {0} no es válido.")]
        public string Email { get; set; }

        // Número de telefono del cliente
        [Display(Name = "Número de Teléfono")]
        [Required(ErrorMessage = "El {0} es requerido.")]
        [Phone(ErrorMessage = "El {0} no es válido.")]
        public string PhoneNumber { get; set; }

        // Direccion del cliente
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        [StringLength(100, ErrorMessage = "La {0} no puede exceder los {1} caracteres.")]
        public string Address { get; set; }

        // Fecha de nacimiento del cliente
        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "La {0} es requerida.")]
        public DateTime DateOfBirth { get; set; }
    }
}
