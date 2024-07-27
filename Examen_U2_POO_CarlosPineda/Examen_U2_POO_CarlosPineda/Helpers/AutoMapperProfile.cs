using AutoMapper;
using LoanAPI.Database.Entities;
using LoanAPI.DTOs;

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

        private void MapsForLoans()
        {
            CreateMap<LoanEntity, LoanDto>()
                .ForMember(dest => dest.AmortizationSchedule, opt => opt.MapFrom(src => src.AmortizationSchedule));
            CreateMap<LoanCreateDto, LoanEntity>();
        }

        private void MapsForAmortizations()
        {
            CreateMap<AmortizationScheduleEntity, AmortizationScheduleDto>();
        }

        private void MapsForCustomers()
        {
            CreateMap<CustomerEntity, CustomerDto>()
                .ForMember(dest => dest.Loans, opt => opt.MapFrom(src => src.Loans));
            CreateMap<CustomerCreateDto, CustomerEntity>();
        }
    }
}
