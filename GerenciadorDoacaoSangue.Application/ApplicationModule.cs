using GerenciadorDoacaoSangue.Application.Commands.DoacaoCommands.ProcessaDoacaoCommand;
using GerenciadorDoacaoSangue.Application.Commands.DoadorCommand.CadastrarDoadorCommand;
using GerenciadorDoacaoSangue.Application.Queries.DoacaoQuery.ConsultaTodasDoacoesQuery;
using GerenciadorDoacaoSangue.Application.Queries.DoadorQuery.ConsultarDoadorPorIdQuery;
using GerenciadorDoacaoSangue.Application.Queries.EstoqueSangueQuery.ConsultaTodoEstoqueSangueQuery;
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
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CadastrarDoadorCommand>();
                cfg.RegisterServicesFromAssemblyContaining<ProcessaDoacaoCommand>();
                cfg.RegisterServicesFromAssemblyContaining<ConsultarDoadorPorIdQuery>();
                cfg.RegisterServicesFromAssemblyContaining<ConsultaTodasDoacoesQuery>();
                cfg.RegisterServicesFromAssemblyContaining<ConsultaTodoEstoqueSangueQuery>();
            });


            return services;
        }
    }
}
