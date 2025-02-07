using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using GerenciadorDoacaoSangue.Infrastructure.Persistence;
using GerenciadorDoacaoSangue.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Tests.Infrastructure
{
    public class DoadorRepositoryTests
    {
        private readonly GerenciadorDoacaoSangueDbContext _dbContext;
        private readonly DoadorRepository _repository;

        public DoadorRepositoryTests()
        {
            // Cria um mock do DbContext
            var options = new DbContextOptionsBuilder<GerenciadorDoacaoSangueDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;
            _dbContext = new GerenciadorDoacaoSangueDbContext(options);
            _repository = new DoadorRepository(_dbContext);
        }

        [Fact]
        public async Task Cadastrar_DeveCadastrarDoadorComSucesso()
        {
            // Arrange
            var doador = new Doador("João da Silva", "joao.silvasucesso@email.com", new DateTime(1990, 5, 15), "Masculino", 80.5m, "O", "+", "Rua das Flores, 123", "Centro", "São Paulo", "SP", "01000-000");

            // Verifica se já existe algum doador com o mesmo email
            var doadorExistente = await _dbContext.Doador.SingleOrDefaultAsync(p => p.Email == doador.Email);
            Assert.Null(doadorExistente); // Verifica que o email não está registrado

            // Act
            await _repository.Cadastrar(doador);

            // Assert
            var doadorCadastrado = await _dbContext.Doador.SingleOrDefaultAsync(p => p.Email == doador.Email);
            Assert.NotNull(doadorCadastrado);
            Assert.Equal(doador.Email, doadorCadastrado.Email);
        }

        [Fact]
        public async Task Cadastrar_DeveLancarExcecaoQuandoEmailExistente()
        {
            // Arrange
            var doador1 = new Doador("João da Silva", "joao.silvaerro@email.com", new DateTime(1990, 5, 15), "Masculino", 80.5m, "O", "+", "Rua das Flores, 123", "Centro", "São Paulo", "SP", "01000-000");
            var doador2 = new Doador("João da Silva", "joao.silvaerro@email.com", new DateTime(1990, 5, 15), "Masculino", 80.5m, "O", "+", "Rua das Flores, 123", "Centro", "São Paulo", "SP", "01000-000");


            // Cadastra o primeiro doador
            await _repository.Cadastrar(doador1);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _repository.Cadastrar(doador2));
            Assert.Equal("Email já existe", exception.Message);
        }

        [Fact]
        public async Task ConsultarPorId_DeveRetornarDoadorQuandoExistir()
        {
            // Arrange
            var doadorId = Guid.NewGuid();
            var doador = new Doador("João da Silva", "joao.silva@email.com", new DateTime(1990, 5, 15), "Masculino", 80.5m, "O", "+", "Rua das Flores, 123", "Centro", "São Paulo", "SP", "01000-000")
            {
                Id = doadorId
            };

            // Adiciona o doador no banco de dados (contexto de memória)
            await _dbContext.Doador.AddAsync(doador);
            await _dbContext.SaveChangesAsync();

            // Act
            var resultado = await _repository.ConsultarPorId(doadorId);

            // Assert
            Assert.NotNull(resultado); // Verifica se o resultado não é nulo
            Assert.Equal(doadorId, resultado.Id); // Verifica se o ID do doador retornado é o mesmo
            Assert.Equal(doador.Email, resultado.Email); // Verifica se o e-mail é o mesmo
        }

        [Fact]
        public async Task ConsultarPorId_DeveLancarNotFoundExceptionQuandoDoadorNaoForEncontrado()
        {
            // Arrange
            var queryId = Guid.NewGuid(); // Um ID qualquer para testar
                                          // Simulando que o doador com esse ID não existe no banco (não há doador com esse ID)
                                          // O método ConsultarPorId retornará null.

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DoadorRepository.NotFoundException>(async () =>
                await _repository.ConsultarPorId(queryId));

            // Verifica se a mensagem da exceção é a esperada
            Assert.Equal("Doador não encontrado", exception.Message);
        }
    }
}
