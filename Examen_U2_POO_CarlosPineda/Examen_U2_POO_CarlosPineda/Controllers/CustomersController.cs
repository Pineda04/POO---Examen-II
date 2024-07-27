using Microsoft.AspNetCore.Mvc;
using LoanAPI.Dtos.Customers;
using LoanAPI.Services.Interfaces;
using Examen_U2_POO_CarlosPineda.Dtos.Common;
using Examen_U2_POO_CarlosPineda.Dtos.Customers;

namespace LoanAPI.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomersService _customersService;

        public CustomersController(ICustomersService customersService)
        {
            this._customersService = customersService;
        }

        // Traer todos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<CustomerDto>>>> GetAll()
        {
            var response = await _customersService.GetCustomersListAsync();

            return StatusCode(response.StatusCode, response);
        }

        // Traer por id
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<CustomerDto>>> Get(Guid id)
        {
            var response = await _customersService.GetCustomerByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        // Crear
        [HttpPost]
        public async Task<ActionResult<ResponseDto<CustomerDto>>> Create(CustomerCreateDto dto)
        {
            var response = await _customersService.CreateAsync(dto);

            return StatusCode(response.StatusCode, response);
        }

        // Editar
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<CustomerDto>>> Edit(CustomerEditDto dto, Guid id)
        {
            var response = await _customersService.EditAsync(dto, id);

            return StatusCode(response.StatusCode, response);
        }

        // Eliminar
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<CustomerDto>>> Delete(Guid id)
        {
            var response = await _customersService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
