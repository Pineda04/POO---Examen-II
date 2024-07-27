using AutoMapper;
using Microsoft.EntityFrameworkCore;
using LoanAPI.Database.Entities;
using LoanAPI.Services.Interfaces;
using Examen_U2_POO_CarlosPineda.Dtos.Common;
using Examen_U2_POO_CarlosPineda.Dtos.Customers;
using LoanAPI.Database;
using LoanAPI.DTOs;

namespace LoanAPI.Services
{
    public class CustomersService : ICustomersService
    {
        private readonly ExamenU2Context _context;
        private readonly IMapper _mapper;

        public CustomersService(ExamenU2Context context, IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<ResponseDto<List<CustomerDto>>> GetCustomersListAsync()
        {
            var customersEntity = await _context.Customers.ToListAsync();
            var customersDtos = _mapper.Map<List<CustomerDto>>(customersEntity);

            return new ResponseDto<List<CustomerDto>>
            {
                StatusCode = 200,
                Status = true,
                Message = "Lista de clientes obtenida correctamente",
                Data = customersDtos
            };
        }

        public async Task<ResponseDto<CustomerDto>> GetCustomerByIdAsync(Guid id)
        {
            var customerEntity = await _context.Customers.FirstOrDefaultAsync(e => e.Id == id);

            if (customerEntity == null)
            {
                return new ResponseDto<CustomerDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el cliente"
                };
            }

            var customerDto = _mapper.Map<CustomerDto>(customerEntity);

            return new ResponseDto<CustomerDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Cliente encontrado correctamente",
                Data = customerDto
            };
        }

        public async Task<ResponseDto<CustomerDto>> CreateAsync(CustomerCreateDto dto)
        {
            var customerEntity = _mapper.Map<CustomerEntity>(dto);

            _context.Customers.Add(customerEntity);
            await _context.SaveChangesAsync();

            var customerDto = _mapper.Map<CustomerDto>(customerEntity);

            return new ResponseDto<CustomerDto>
            {
                StatusCode = 201,
                Status = true,
                Message = "Cliente creado exitosamente",
                Data = customerDto
            };
        }

        public async Task<ResponseDto<CustomerDto>> EditAsync(CustomerEditDto dto, Guid id)
        {
            var customerEntity = await _context.Customers.FirstOrDefaultAsync(e => e.Id == id);

            if (customerEntity == null)
            {
                return new ResponseDto<CustomerDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el cliente"
                };
            }

            _mapper.Map(dto, customerEntity);
            _context.Customers.Update(customerEntity);
            await _context.SaveChangesAsync();

            var customerDto = _mapper.Map<CustomerDto>(customerEntity);

            return new ResponseDto<CustomerDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Cliente modificado exitosamente",
                Data = customerDto
            };
        }

        public async Task<ResponseDto<CustomerDto>> DeleteAsync(Guid id)
        {
            var customerEntity = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

            if (customerEntity == null)
            {
                return new ResponseDto<CustomerDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el cliente"
                };
            }

            _context.Customers.Remove(customerEntity);
            await _context.SaveChangesAsync();

            return new ResponseDto<CustomerDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Cliente eliminado correctamente"
            };
        }

        // Pa traer al cliente con la info de su prestamo y amortizacion
        public async Task<ResponseDto<CustomerDto>> GetCustomerWithLoansAndAmortizationAsync(Guid customerId)
        {
            var customerEntity = await _context.Customers
                .Include(c => c.Loans)
                .ThenInclude(l => l.AmortizationSchedule)
                .FirstOrDefaultAsync(e => e.Id == customerId);

            if (customerEntity == null)
            {
                return new ResponseDto<CustomerDto>
                {
                    StatusCode = 404,
                    Status = false,
                    Message = "No se encontro el cliente"
                };
            }

            var customerDto = _mapper.Map<CustomerDto>(customerEntity);

            return new ResponseDto<CustomerDto>
            {
                StatusCode = 200,
                Status = true,
                Message = "Cliente con prestamos y amortizaciones obtenido correctamente",
                Data = customerDto
            };
        }
    }
}
