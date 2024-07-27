using AutoMapper;
using LoanAPI.Database.Entities;
using LoanAPI.Dtos.Customers;
using LoanAPI.Dtos.Loans;
using Examen_U2_POO_CarlosPineda.Dtos.AmortizationSchedules;
using Examen_U2_POO_CarlosPineda.Dtos.Customers;
using Examen_U2_POO_CarlosPineda.Dtos.Loans;
using LoanAPI.Dtos;

namespace LoanAPI.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeos para Préstamos
            MapsForLoans();

            // Mapeos para Amortizaciones
            MapsForAmortizations();

            // Mapeos para Clientes
            MapsForCustomers();
        }

        // Mapper de Préstamos
        private void MapsForLoans()
        {
            CreateMap<LoanEntity, LoanDto>();
            CreateMap<LoanCreateDto, LoanEntity>();
            CreateMap<LoanEditDto, LoanEntity>();
        }

        // Mapper de Amortizaciones
        private void MapsForAmortizations()
        {
            CreateMap<AmortizationScheduleEntity, AmortizationScheduleDto>();
            CreateMap<AmortizationScheduleCreateDto, AmortizationScheduleEntity>();
            CreateMap<AmortizationScheduleEditDto, AmortizationScheduleEntity>();
        }

        // Mapper de Clientes
        private void MapsForCustomers()
        {
            CreateMap<CustomerEntity, CustomerDto>();
            CreateMap<CustomerCreateDto, CustomerEntity>();
            CreateMap<CustomerEditDto, CustomerEntity>();
        }
    }
}
