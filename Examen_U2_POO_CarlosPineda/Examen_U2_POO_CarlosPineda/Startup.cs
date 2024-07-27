using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LoanAPI.Helpers;
using LoanAPI.Database;
using LoanAPI.Services.Interfaces;
using LoanAPI.Services;

namespace ProyectoViajes.API
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Add DbContext
            services.AddDbContext<ExamenU2Context>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Add servicios de Agency
            services.AddTransient<ICustomersService, CustomersService>();
            services.AddTransient<ILoansService, LoansService>();

            // Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfile));
        }

        private Action<IMapperConfigurationExpression> nameof(AutoMapperProfile autoMapperProfile)
        {
            throw new NotImplementedException();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
