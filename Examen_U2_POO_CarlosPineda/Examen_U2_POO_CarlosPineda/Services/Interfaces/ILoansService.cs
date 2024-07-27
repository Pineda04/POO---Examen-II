using LoanAPI.Dtos.Loans;
using Examen_U2_POO_CarlosPineda.Dtos.Common;
using Examen_U2_POO_CarlosPineda.Dtos.Loans;

namespace LoanAPI.Services.Interfaces
{
    public interface ILoansService
    {
        Task<ResponseDto<List<LoanDto>>> GetLoansListAsync();

        Task<ResponseDto<LoanDto>> GetLoanByClientIdAsync(Guid clientId);

        Task<ResponseDto<LoanDto>> CreateAsync(LoanCreateDto dto);

        Task<ResponseDto<LoanDto>> EditAsync(LoanEditDto dto, Guid id);

        Task<ResponseDto<LoanDto>> DeleteAsync(Guid id);
    }
}
