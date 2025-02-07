using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Infrastructure.Persistence;
using GerenciadorDoacaoSangue.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDoacaoSangue.Tests.Infrastructure
{
    public class EstoqueSangueRepositoryTests
    {
        private readonly GerenciadorDoacaoSangueDbContext _dbContext;
        private readonly EstoqueSangueRepository _repository;

        public EstoqueSangueRepositoryTests()
        {
            // Cria um banco de dados em memória para os testes
            var options = new DbContextOptionsBuilder<GerenciadorDoacaoSangueDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            _dbContext = new GerenciadorDoacaoSangueDbContext(options);
            _repository = new EstoqueSangueRepository(_dbContext);
        }

        [Fact]
        public async Task ConsultaTodoEstoqueSangue_DeveRetornarNullQuandoNaoExistirEstoque()
        {
            // Act
            var resultado = await _repository.ConsultaTodoEstoqueSangue();
            if (resultado == null)
                throw new Exception();

            // Assert
            Assert.Empty(resultado); // Quando não houver estoque, deve retornar null
        }

        [Fact]
        public async Task ConsultaTodoEstoqueSangue_DeveRetornarListaComEstoque()
        {
            // Arrange
            var estoqueSangue1 = new EstoqueSangue("O", "+", 500);
            var estoqueSangue2 = new EstoqueSangue("A", "-", 300);
            await _dbContext.EstoqueSangue.AddAsync(estoqueSangue1);
            await _dbContext.EstoqueSangue.AddAsync(estoqueSangue2);
            await _dbContext.SaveChangesAsync();

            // Act
            var resultado = await _repository.ConsultaTodoEstoqueSangue();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count);
            Assert.Contains(resultado, e => e.TipoSanguineo == "O" && e.QuantidadeML == 500);
            Assert.Contains(resultado, e => e.TipoSanguineo == "A" && e.QuantidadeML == 300);
        }        
    }
}
