using Microsoft.AspNetCore.Mvc;
using LoanAPI.Services.Interfaces;
using Examen_U2_POO_CarlosPineda.Dtos.Common;
using Examen_U2_POO_CarlosPineda.Dtos.Customers;
using LoanAPI.DTOs;

namespace LoanAPI.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            _customersService = customersService;
        }

        // Obtener la lista de clientes
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<CustomerDto>>>> GetAll()
        {
            var response = await _customersService.GetCustomersListAsync();
            return StatusCode(response.StatusCode, response);
        }

        // Obtener un cliente por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<CustomerDto>>> Get(Guid id)
        {
            var response = await _customersService.GetCustomerByIdAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        // Crear un nuevo cliente
        [HttpPost]
        public async Task<ActionResult<ResponseDto<CustomerDto>>> Create(CustomerCreateDto dto)
        {
            var response = await _customersService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        // Editar un cliente existente
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<CustomerDto>>> Edit(CustomerEditDto dto, Guid id)
        {
            var response = await _customersService.EditAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        // Eliminar un cliente
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<CustomerDto>>> Delete(Guid id)
        {
            var response = await _customersService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }

        // Obtener un cliente con prestamos y amortizaciones
        [HttpGet("{customerId}/loans")]
        public async Task<ActionResult<ResponseDto<CustomerDto>>> GetCustomerWithLoansAndAmortization(Guid customerId)
        {
            var response = await _customersService.GetCustomerWithLoansAndAmortizationAsync(customerId);
            return StatusCode(response.StatusCode, response);
        }
    }
}
