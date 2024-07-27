using LoanAPI.Dtos.Customers;
using Examen_U2_POO_CarlosPineda.Dtos.Common;
using Examen_U2_POO_CarlosPineda.Dtos.Customers;

namespace LoanAPI.Services.Interfaces
{
    public interface ICustomersService
    {
        Task<ResponseDto<List<CustomerDto>>> GetCustomersListAsync();

        Task<ResponseDto<CustomerDto>> GetCustomerByIdAsync(Guid id);

        Task<ResponseDto<CustomerDto>> CreateAsync(CustomerCreateDto dto);

        Task<ResponseDto<CustomerDto>> EditAsync(CustomerEditDto dto, Guid id);

        Task<ResponseDto<CustomerDto>> DeleteAsync(Guid id);
    }
}
