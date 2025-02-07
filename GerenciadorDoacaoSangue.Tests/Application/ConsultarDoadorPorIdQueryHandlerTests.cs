using GerenciadorDoacaoSangue.Application.Commands.DoacaoCommands.ProcessaDoacaoCommand;
using GerenciadorDoacaoSangue.Application.Commands.DoadorCommand.CadastrarDoadorCommand;
using GerenciadorDoacaoSangue.Application.Queries.DoadorQuery.ConsultarDoadorPorIdQuery;
using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using GerenciadorDoacaoSangue.Infrastructure.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Tests.Application
{
    public class ConsultarDoadorPorIdQueryHandlerTests
    {
        private readonly IDoadorRepository _doadorRepository;
        private readonly ConsultarDoadorPorIdQueryHandler _handler;

        public ConsultarDoadorPorIdQueryHandlerTests()
        {
            // Cria o mock do repositório de doador
            _doadorRepository = Substitute.For<IDoadorRepository>();
            _handler = new ConsultarDoadorPorIdQueryHandler(_doadorRepository);
        }
        [Fact]
        public async Task ConsultaFeitoComSucesso_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IDoadorRepository>();
            var doadorMock = new Doador("João Silva", " ", DateTime.Now, " ", 80, " ", " ", " ", " ", " ", " ", " ");

            Guid id = Guid.NewGuid();
            repository.ConsultarPorId(Arg.Any<Guid>()).Returns(Task.FromResult(doadorMock));

            var command = new ConsultarDoadorPorIdQuery(id)
            {
                Id = id
            };

            var handler = new ConsultarDoadorPorIdQueryHandler(repository);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.Sucesso);

        }

        [Fact]
        public async Task ConsultaFeitoComErro_NSubistitute()
        {
            // Arrange
            var query = new ConsultarDoadorPorIdQuery(Guid.NewGuid()); // Um ID de doador qualquer
            _doadorRepository.ConsultarPorId(Arg.Is<Guid>(x => x == query.Id)).Returns(Task.FromResult<Doador>(null)); // Retorna null para indicar que o doador não foi encontrado

            // Act & Assert
            // Verificando se a exceção é lançada corretamente
            var exception = await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await _handler.Handle(query, CancellationToken.None));

            // Verifica se a mensagem de exceção é a esperada
            Assert.Equal("Nenhuma doador encontrado.", exception.Message);

        }

        [Fact]
        public async Task DoadorNaoExiste_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IDoacaoRepository>();
            repository.ProcessarDoacao(Arg.Any<Doacao>()).Returns(Task.FromResult(1));

            var command = new ProcessaDoacaoCommand
            {
                DoadorId = Guid.NewGuid(),
                DataDoacao = DateTime.Now,
                QuantidadeML = 800,
                DataNascimento = DateTime.Now.AddYears(-20),
                Genero = "Feminino",
                DataUltimaDoacao = DateTime.Now.AddDays(-91)
            };

            var handler = new ProcessaDoacaoCommandHandler(repository);

            // Act 
            var exception = await Assert.ThrowsAsync<ArgumentException>(
                async () => await handler.Handle(command, new CancellationToken())
            );

            //Assert
            Assert.Contains("Quantidade fora do permitido", exception.Message);
        }       
    }
}
