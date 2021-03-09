using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Services.Services;

namespace Services
{
    public static class DependencyInjection
    {
        public static void AddCbService(this IServiceCollection services)
        {
            services.AddScoped<ICurrencyValues, CentralBankValues>();
        }
    }
}
