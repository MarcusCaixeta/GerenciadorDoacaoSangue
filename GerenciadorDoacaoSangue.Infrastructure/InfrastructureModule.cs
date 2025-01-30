using GerenciadorDoacaoSangue.Core.Repositories;
using GerenciadorDoacaoSangue.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorDoacaoSangue.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddRepositories();

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IDoadorRepository, DoadorRepository>();
            services.AddScoped<IDoacaoRepository, DoacaoRapository>();
            services.AddScoped<IEstoqueSangueRepository, EstoqueSangueRepository>();

            return services;
        }
    }
}
