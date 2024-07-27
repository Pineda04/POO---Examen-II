using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LoanAPI.Database.Entities;
using LoanAPI.Services.Interfaces;
using Examen_U2_POO_CarlosPineda.Dtos.AmortizationSchedules;
using Examen_U2_POO_CarlosPineda.Dtos.Common;
using LoanAPI.Dtos;
using LoanAPI.Database;

namespace LoanAPI.Services
{
    public class AmortizationSchedulesService : IAmortizationSchedulesService
    {
        private readonly ExamenU2Context _context;
        private readonly IMapper _mapper;

        public AmortizationSchedulesService(ExamenU2Context context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ResponseDto<List<AmortizationScheduleDto>>> GetAmortizationSchedulesListAsync(Guid loanId)
        {
            var amortizationSchedulesEntity = await _context.AmortizationSchedules
                .Where(a => a.LoanId == loanId)
                .ToListAsync();
            var amortizationSchedulesDtos = _mapper.Map<List<AmortizationScheduleDto>>(amortizationSchedulesEntity);

            return new ResponseDto<List<AmortizationScheduleDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de amortizaciones obtenida correctamente",
                Data = amortizationSchedulesDtos
            };
        }

        public async Task<ResponseDto<AmortizationScheduleDto>> GetAmortizationScheduleByIdAsync(Guid id)
        {
            var amortizationScheduleEntity = await _context.AmortizationSchedules
                .FirstOrDefaultAsync(a => a.Id == id);

            if (amortizationScheduleEntity == null)
            {
                return new ResponseDto<AmortizationScheduleDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró la amortización"
                };
            }

            var amortizationScheduleDto = _mapper.Map<AmortizationScheduleDto>(amortizationScheduleEntity);

            return new ResponseDto<AmortizationScheduleDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Amortización encontrada correctamente",
                Data = amortizationScheduleDto
            };
        }

        public async Task<ResponseDto<AmortizationScheduleDto>> CreateAsync(AmortizationScheduleCreateDto dto)
        {
            var amortizationScheduleEntity = _mapper.Map<AmortizationScheduleEntity>(dto);

            _context.AmortizationSchedules.Add(amortizationScheduleEntity);

            await _context.SaveChangesAsync();

            var amortizationScheduleDto = _mapper.Map<AmortizationScheduleDto>(amortizationScheduleEntity);

            return new ResponseDto<AmortizationScheduleDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Amortización creada exitosamente",
                Data = amortizationScheduleDto
            };
        }

        public async Task<ResponseDto<AmortizationScheduleDto>> EditAsync(AmortizationScheduleEditDto dto, Guid id)
        {
            var amortizationScheduleEntity = await _context.AmortizationSchedules
                .FirstOrDefaultAsync(a => a.Id == id);

            if (amortizationScheduleEntity == null)
            {
                return new ResponseDto<AmortizationScheduleDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró la amortización"
                };
            }

            _mapper.Map(dto, amortizationScheduleEntity);

            _context.AmortizationSchedules.Update(amortizationScheduleEntity);

            await _context.SaveChangesAsync();

            var amortizationScheduleDto = _mapper.Map<AmortizationScheduleDto>(amortizationScheduleEntity);

            return new ResponseDto<AmortizationScheduleDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Amortización actualizada exitosamente",
                Data = amortizationScheduleDto
            };
        }

        public async Task<ResponseDto<AmortizationScheduleDto>> DeleteAsync(Guid id)
        {
            var amortizationScheduleEntity = await _context.AmortizationSchedules
                .FirstOrDefaultAsync(a => a.Id == id);

            if (amortizationScheduleEntity == null)
            {
                return new ResponseDto<AmortizationScheduleDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontró la amortización"
                };
            }

            _context.AmortizationSchedules.Remove(amortizationScheduleEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<AmortizationScheduleDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Amortización eliminada correctamente"
            };
        }
    }
}
