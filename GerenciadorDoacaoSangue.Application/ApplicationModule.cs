using GerenciadorDoacaoSangue.Application.Commands.Doadores.CadastrarDoadorCommand;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediator();

            return services;
        }

        private static IServiceCollection AddMediator(this IServiceCollection services)
        {
            services.AddMediatR(o => o.RegisterServicesFromAssemblyContaining<CadastrarDoadorCommand>());

            return services;
        }
    }
}
