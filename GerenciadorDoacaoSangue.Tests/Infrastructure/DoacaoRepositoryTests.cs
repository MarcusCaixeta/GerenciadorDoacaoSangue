using Azure.Core;
using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Infrastructure.Persistence;
using GerenciadorDoacaoSangue.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Tests.Infrastructure
{
    public class DoacaoRepositoryTests
    {
        private readonly GerenciadorDoacaoSangueDbContext _dbContext;
        private readonly DoacaoRepository _doacaoRepository;

        public DoacaoRepositoryTests()
        {
            // Cria um mock do DbContext
            var options = new DbContextOptionsBuilder<GerenciadorDoacaoSangueDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;
            _dbContext = new GerenciadorDoacaoSangueDbContext(options);
            _doacaoRepository = new DoacaoRepository(_dbContext);
        }


        [Fact]
        public async Task ProcessarDoacao_DeveLancarNotFoundException_QuandoDoadorNaoEncontrado()
        {
            // Arrange
            var doacao = new Doacao(new Guid(), DateTime.Now, 500);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<DoacaoRepository.NotFoundException>(
                () => _doacaoRepository.ProcessarDoacao(doacao)
            );

            Assert.Equal("Doador não encontrado", exception.Message);
        }

        [Fact]
        public async Task ProcessarDoacao_DeveAdicionarDoacao_EAtualizarEstoqueSangue_QuandoDoadorExistir()
        {
            try
            {
                // Arrange

                var doador = new Doador("João da Silva", "joao.silvadoacao1@email.com", new DateTime(1990, 5, 15), "Masculino", 80.5m, "J", "+", "Rua das Flores, 123", "Centro", "São Paulo", "SP", "01000-000");
                var doacao = new Doacao(doador.Id, DateTime.Now, 500);

                 await _dbContext.Doador.AddAsync(doador);
                await _dbContext.SaveChangesAsync();

                // Act
                await _doacaoRepository.ProcessarDoacao(doacao);

                // Assert
                var doacoes = await _dbContext.Doacao.SingleOrDefaultAsync(e => e.DoadorId == doador.Id);

                Assert.Equal(500, doacoes.QuantidadeML);

                var estoqueSangue = await _dbContext.EstoqueSangue.SingleOrDefaultAsync(e => e.TipoSanguineo == doador.TipoSanguineo);
                Assert.NotNull(estoqueSangue);
                Assert.Equal(500, estoqueSangue.QuantidadeML);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [Fact]
        public async Task ProcessarDoacao_DeveCriarNovoEstoqueSangue_QuandoNaoExistirEstoque()
        {
            // Arrange
            var doador = new Doador("João da Silva", "joao.silvadoacao2@email.com", new DateTime(1990, 5, 15), "Masculino", 80.5m, "H", "+", "Rua das Flores, 123", "Centro", "São Paulo", "SP", "01000-000");
            var doacao = new Doacao(doador.Id, DateTime.Now.AddDays(-180), 500);

            await _dbContext.Doador.AddAsync(doador);
            await _dbContext.SaveChangesAsync();

            // Act
            await _doacaoRepository.ProcessarDoacao(doacao);

            // Assert
            var estoqueSangue = await _dbContext.EstoqueSangue.SingleOrDefaultAsync(e => e.TipoSanguineo == doador.TipoSanguineo);
            Assert.NotNull(estoqueSangue);
            Assert.Equal(500, estoqueSangue.QuantidadeML);
        }

        [Fact]
        public async Task ConsultaTodasDoacoes()
        {
            var doador = new Doador("João da Silva", "joao.silvadoacao2@email.com", new DateTime(1990, 5, 15), "Masculino", 80.5m, "L", "+", "Rua das Flores, 123", "Centro", "São Paulo", "SP", "01000-000");
            var doacao = new Doacao(doador.Id, DateTime.Now.AddDays(-180), 500);

            await _dbContext.Doador.AddAsync(doador);
            await _dbContext.SaveChangesAsync();

            await _doacaoRepository.ProcessarDoacao(doacao);


            // Act
            var resultado = await _doacaoRepository.ConsultaTodasDoacoes();

            // Assert
            Assert.NotNull(resultado);
        }

        //[Fact]
        //public async Task ConsultaTodasDoacoes_DeveLancarNotFoundExceptionQuandoNaoHouverDoacoes()
        //{
        //    // Arrange: O banco de dados está vazio (nenhuma doação foi adicionada)

        //    // Act & Assert: Verifica se a exceção é lançada quando não houver doações
        //    var exception = await Assert.ThrowsAsync<DoacaoRepository.NotFoundException>(async () =>
        //        await _doacaoRepository.ConsultaTodasDoacoes());

        //    // Verifica se a mensagem da exceção é a esperada
        //    Assert.Equal("Doação não encontrada", exception.Message);
        //}
    }
}
