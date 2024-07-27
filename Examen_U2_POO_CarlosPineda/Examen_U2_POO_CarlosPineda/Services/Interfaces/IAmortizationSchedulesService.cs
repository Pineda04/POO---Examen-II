using Examen_U2_POO_CarlosPineda.Dtos.AmortizationSchedules;
using Examen_U2_POO_CarlosPineda.Dtos.Common;
using LoanAPI.Dtos;

namespace LoanAPI.Services.Interfaces
{
    public interface IAmortizationSchedulesService
    {
        Task<ResponseDto<List<AmortizationScheduleDto>>> GetAmortizationSchedulesListAsync(Guid loanId);

        Task<ResponseDto<AmortizationScheduleDto>> GetAmortizationScheduleByIdAsync(Guid id);

        Task<ResponseDto<AmortizationScheduleDto>> CreateAsync(AmortizationScheduleCreateDto dto);

        Task<ResponseDto<AmortizationScheduleDto>> EditAsync(AmortizationScheduleEditDto dto, Guid id);

        Task<ResponseDto<AmortizationScheduleDto>> DeleteAsync(Guid id);
    }
}
