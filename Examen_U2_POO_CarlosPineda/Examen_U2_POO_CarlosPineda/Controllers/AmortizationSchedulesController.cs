using Microsoft.AspNetCore.Mvc;
using LoanAPI.Services.Interfaces;
using Examen_U2_POO_CarlosPineda.Dtos.AmortizationSchedules;
using Examen_U2_POO_CarlosPineda.Dtos.Common;
using LoanAPI.Dtos;

namespace LoanAPI.Controllers
{
    [ApiController]
    [Route("api/loans/{loanId}/amortizations")]
    public class AmortizationSchedulesController : ControllerBase
    {
        private readonly IAmortizationSchedulesService _amortizationSchedulesService;

        public AmortizationSchedulesController(IAmortizationSchedulesService amortizationSchedulesService)
        {
            _amortizationSchedulesService = amortizationSchedulesService;
        }

        // Obtener todas las amortizaciones para un préstamo
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<AmortizationScheduleDto>>>> GetAll(Guid loanId)
        {
            var response = await _amortizationSchedulesService.GetAmortizationSchedulesListAsync(loanId);

            return StatusCode(response.StatusCode, response);
        }

        // Obtener amortización por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<AmortizationScheduleDto>>> Get(Guid id)
        {
            var response = await _amortizationSchedulesService.GetAmortizationScheduleByIdAsync(id);

            return StatusCode(response.StatusCode, response);
        }

        // Crear una nueva amortización
        [HttpPost]
        public async Task<ActionResult<ResponseDto<AmortizationScheduleDto>>> Create(AmortizationScheduleCreateDto dto)
        {
            var response = await _amortizationSchedulesService.CreateAsync(dto);

            return StatusCode(response.StatusCode, response);
        }

        // Editar una amortización existente
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<AmortizationScheduleDto>>> Edit(AmortizationScheduleEditDto dto, Guid id)
        {
            var response = await _amortizationSchedulesService.EditAsync(dto, id);

            return StatusCode(response.StatusCode, response);
        }

        // Eliminar una amortización
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<AmortizationScheduleDto>>> Delete(Guid id)
        {
            var response = await _amortizationSchedulesService.DeleteAsync(id);

            return StatusCode(response.StatusCode, response);
        }
    }
}
