using GerenciadorDoacaoSangue.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Tests.Infrastructure
{
    public class TestGerenciadorDoacaoSangueDbContext : GerenciadorDoacaoSangueDbContext
    {
        // Construtor que chama o base para usar as opções
        public TestGerenciadorDoacaoSangueDbContext(DbContextOptions<GerenciadorDoacaoSangueDbContext> options)
            : base(options)
        { }

        // Tornando OnModelCreating público para o teste
        public new void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
    public class InfrastructureTests
    {
        [Fact]
        public void OnModelCreating_ShouldCallApplyConfigurationsFromAssembly()
        {
            // Arrange
            var options = new DbContextOptions<GerenciadorDoacaoSangueDbContext>(); // DbContextOptions mockado
            var dbContextMock = Substitute.For<TestGerenciadorDoacaoSangueDbContext>(options);

            // Criando um mock do ModelBuilder
            var modelBuilderMock = Substitute.For<ModelBuilder>();

            // Act
            // Chama o método OnModelCreating, que deve invocar ApplyConfigurationsFromAssembly
            dbContextMock.OnModelCreating(modelBuilderMock);

            // Assert
            // Verifica se ApplyConfigurationsFromAssembly foi chamado no ModelBuilder
            modelBuilderMock.Received().ApplyConfigurationsFromAssembly(Arg.Any<Assembly>());
        }
    }
}
