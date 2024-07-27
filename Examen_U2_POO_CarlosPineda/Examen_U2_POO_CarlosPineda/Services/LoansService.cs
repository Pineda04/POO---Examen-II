using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LoanAPI.Database;
using LoanAPI.Database.Entities;
using LoanAPI.Dtos.Loans;
using LoanAPI.Services.Interfaces;
using Examen_U2_POO_CarlosPineda.Dtos.Common;
using Examen_U2_POO_CarlosPineda.Dtos.Loans;

namespace LoanAPI.Services
{
    public class LoansService : ILoansService
    {
        private readonly ExamenU2Context _context;
        private readonly IMapper _mapper;

        public LoansService(ExamenU2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<LoanDto>>> GetLoansListAsync()
        {
            var loansEntity = await _context.Loans.ToListAsync();
            var loansDtos = _mapper.Map<List<LoanDto>>(loansEntity);

            return new ResponseDto<List<LoanDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de préstamos obtenida correctamente",
                Data = loansDtos
            };
        }

        public async Task<ResponseDto<LoanDto>> GetLoanByClientIdAsync(Guid clientId)
        {
            var loanEntity = await _context.Loans
                .FirstOrDefaultAsync(e => e.IdentityNumber == clientId);

            if (loanEntity == null)
            {
                return new ResponseDto<LoanDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Préstamo no encontrado"
                };
            }

            var loanDto = _mapper.Map<LoanDto>(loanEntity);

            return new ResponseDto<LoanDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Préstamo encontrado correctamente",
                Data = loanDto
            };
        }

        public async Task<ResponseDto<LoanDto>> CreateAsync(LoanCreateDto dto)
        {
            var loanEntity = _mapper.Map<LoanEntity>(dto);

            _context.Loans.Add(loanEntity);

            await _context.SaveChangesAsync();

            var loanDto = _mapper.Map<LoanDto>(loanEntity);

            return new ResponseDto<LoanDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Préstamo creado exitosamente",
                Data = loanDto
            };
        }

        public async Task<ResponseDto<LoanDto>> EditAsync(LoanEditDto dto, Guid id)
        {
            var loanEntity = await _context.Loans.FirstOrDefaultAsync(e => e.Id == id);

            if (loanEntity == null)
            {
                return new ResponseDto<LoanDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Préstamo no encontrado"
                };
            }

            _mapper.Map(dto, loanEntity);

            _context.Loans.Update(loanEntity);

            await _context.SaveChangesAsync();

            var loanDto = _mapper.Map<LoanDto>(loanEntity);

            return new ResponseDto<LoanDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Préstamo modificado exitosamente",
                Data = loanDto
            };
        }

        public async Task<ResponseDto<LoanDto>> DeleteAsync(Guid id)
        {
            var loanEntity = await _context.Loans.FirstOrDefaultAsync(e => e.Id == id);

            if (loanEntity == null)
            {
                return new ResponseDto<LoanDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "Préstamo no encontrado"
                };
            }

            _context.Loans.Remove(loanEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<LoanDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Préstamo eliminado correctamente"
            };
        }
    }
}