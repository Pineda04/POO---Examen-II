using Microsoft.AspNetCore.Mvc;
using LoanAPI.Dtos.Loans;
using LoanAPI.Services.Interfaces;
using System;
using System.Threading.Tasks;
using Examen_U2_POO_CarlosPineda.Dtos.Common;
using Examen_U2_POO_CarlosPineda.Dtos.Loans;

namespace LoanAPI.Controllers
{
    [ApiController]
    [Route("api/loans")]
    public class LoansController : ControllerBase
    {
        private readonly ILoansService _loansService;

        public LoansController(ILoansService loansService)
        {
            _loansService = loansService;
        }

        // Traer todos los préstamos
        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<LoanDto>>>> GetAll()
        {
            var response = await _loansService.GetLoansListAsync();
            return StatusCode(response.StatusCode, response);
        }

        // Traer préstamo por ID de cliente
        [HttpGet("client/{clientId}")]
        public async Task<ActionResult<ResponseDto<LoanDto>>> GetByClientId(Guid clientId)
        {
            var response = await _loansService.GetLoanByClientIdAsync(clientId);
            return StatusCode(response.StatusCode, response);
        }

        // Crear un nuevo préstamo
        [HttpPost]
        public async Task<ActionResult<ResponseDto<LoanDto>>> Create(LoanCreateDto dto)
        {
            var response = await _loansService.CreateAsync(dto);
            return StatusCode(response.StatusCode, response);
        }

        // Editar un préstamo
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseDto<LoanDto>>> Edit(LoanEditDto dto, Guid id)
        {
            var response = await _loansService.EditAsync(dto, id);
            return StatusCode(response.StatusCode, response);
        }

        // Eliminar un préstamo
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseDto<LoanDto>>> Delete(Guid id)
        {
            var response = await _loansService.DeleteAsync(id);
            return StatusCode(response.StatusCode, response);
        }
    }
}