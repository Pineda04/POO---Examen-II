using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LoanAPI.Database.Entities;
using LoanAPI.Services.Interfaces;
using Examen_U2_POO_CarlosPineda.Dtos.Common;
using Examen_U2_POO_CarlosPineda.Dtos.Loans;
using LoanAPI.Database;
using LoanAPI.DTOs;

namespace LoanAPI.Services
{
    public class LoansService : ILoansService
    {
        private readonly ExamenU2Context _context;
        private readonly IMapper _mapper;

        public LoansService(ExamenU2Context context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ResponseDto<List<LoanDto>>> GetLoansListAsync()
        {
            var loansEntity = await _context.Loans.Include(l => l.AmortizationSchedule).ToListAsync();
            var loansDtos = _mapper.Map<List<LoanDto>>(loansEntity);

            return new ResponseDto<List<LoanDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de prestamos obtenida correctamente",
                Data = loansDtos
            };
        }

        public async Task<ResponseDto<LoanDto>> GetLoanByIdentityNumberAsync(string identityNumber)
        {
            var loanEntity = await _context.Loans
                .Include(l => l.AmortizationSchedule)
                .FirstOrDefaultAsync(e => e.IdentityNumber == identityNumber);

            if (loanEntity == null)
            {
                return new ResponseDto<LoanDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el prestamo"
                };
            }

            var loanDto = _mapper.Map<LoanDto>(loanEntity);

            return new ResponseDto<LoanDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Prestamo encontrado correctamente",
                Data = loanDto
            };
        }

        public async Task<ResponseDto<LoanDto>> CreateAsync(LoanCreateDto dto)
        {
            var loanEntity = _mapper.Map<LoanEntity>(dto);
            _context.Loans.Add(loanEntity);

            await _context.SaveChangesAsync();

            // Aqui voy a poner el calculo del plan de amortización

            var loanDto = _mapper.Map<LoanDto>(loanEntity);

            return new ResponseDto<LoanDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Prestamo creado exitosamente",
                Data = loanDto
            };
        }

        public async Task<ResponseDto<LoanDto>> EditAsync(LoanEditDto dto, Guid id)
        {
            var loanEntity = await _context.Loans
                .Include(l => l.AmortizationSchedule)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (loanEntity == null)
            {
                return new ResponseDto<LoanDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el prestamo"
                };
            }

            _mapper.Map(dto, loanEntity);
            _context.Loans.Update(loanEntity);
            await _context.SaveChangesAsync();

            // Aqui tendria que volver a calcular la amortizacion
            

            var loanDto = _mapper.Map<LoanDto>(loanEntity);

            return new ResponseDto<LoanDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Prestamo modificado exitosamente",
                Data = loanDto
            };
        }

        public async Task<ResponseDto<LoanDto>> DeleteAsync(Guid id)
        {
            var loanEntity = await _context.Loans
                .Include(l => l.AmortizationSchedule)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (loanEntity == null)
            {
                return new ResponseDto<LoanDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el prestamo"
                };
            }

            _context.Loans.Remove(loanEntity);
            _context.AmortizationSchedules.RemoveRange(loanEntity.AmortizationSchedule);
            await _context.SaveChangesAsync();

            return new ResponseDto<LoanDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Prestamo eliminado correctamente"
            };
        }

        // Para traer el prestmo junto con su amortizacion
        public async Task<ResponseDto<LoanDto>> GetLoanWithAmortizationAsync(Guid loanId)
        {
            var loanEntity = await _context.Loans
                .Include(l => l.AmortizationSchedule)
                .FirstOrDefaultAsync(e => e.Id == loanId);

            if (loanEntity == null)
            {
                return new ResponseDto<LoanDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el prestamo"
                };
            }

            var loanDto = _mapper.Map<LoanDto>(loanEntity);

            return new ResponseDto<LoanDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Prestamo con plan de amortizacion obtenido correctamente",
                Data = loanDto
            };
        }

        /* Metodo para caulcular la amortizacón
        private List<AmortizationScheduleEntity> CalculateAmortizationSchedule(LoanEntity loanEntity)
        {
            
        }*/
    }
}