using GerenciadorDoacaoSangue.Application;
using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using GerenciadorDoacaoSangue.Infrastructure;
using GerenciadorDoacaoSangue.Infrastructure.Persistence;
using GerenciadorDoacaoSangue.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;

namespace GerenciadorDoacaoSangue.Tests.Application
{
    public class ApplicationModuleTests
    {
        [Fact]
        public void AddApplication_DeveRegistrarMediatR()
        {
            // Arrange
            var services = new ServiceCollection();
            services.AddApplication();

            // Criando um ServiceProvider
            using var serviceProvider = services.BuildServiceProvider();

            // Act
            var mediator = serviceProvider.GetService<IMediator>();

            // Assert
            Assert.NotNull(mediator);
        }

        [Fact]
        public void DeveResolverORepositórioSemDbContextReal()
        {
            // Arrange
            var services = new ServiceCollection();

            // Adicionar InMemory Database
            services.AddDbContext<GerenciadorDoacaoSangueDbContext>(options =>
                options.UseInMemoryDatabase("TestDatabase")
            );

            // Registrar os repositórios
            services.AddScoped<IDoadorRepository, DoadorRepository>();
            services.AddScoped<IDoacaoRepository, DoacaoRepository>();
            services.AddScoped<IEstoqueSangueRepository, EstoqueSangueRepository>();

            // Registrar a aplicação e infraestrutura
            services.AddApplication();
            services.AddInfrastructure();

            var serviceProvider = services.BuildServiceProvider();

            // Act
            var doadorRepository = serviceProvider.GetService<IDoadorRepository>();
            var doacaoRepository = serviceProvider.GetService<IDoacaoRepository>();
            var estoqueSangueRepository = serviceProvider.GetService<IEstoqueSangueRepository>();

            // Assert
            Assert.NotNull(doadorRepository);
            Assert.NotNull(doacaoRepository);
            Assert.NotNull(estoqueSangueRepository);
        }
    }
    
}
