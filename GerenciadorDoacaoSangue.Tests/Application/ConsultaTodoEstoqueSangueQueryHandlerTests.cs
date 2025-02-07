using GerenciadorDoacaoSangue.Application.Commands.DoadorCommand.CadastrarDoadorCommand;
using GerenciadorDoacaoSangue.Application.Queries.DoacaoQuery.ConsultaTodasDoacoesQuery;
using GerenciadorDoacaoSangue.Application.Queries.DoadorQuery.ConsultarDoadorPorIdQuery;
using GerenciadorDoacaoSangue.Application.Queries.EstoqueSangueQuery.ConsultaTodoEstoqueSangueQuery;
using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Tests.Application
{
    public class ConsultaTodoEstoqueSangueQueryHandlerTests
    {
        [Fact]
        public async Task ConsultaFeitoComSucesso_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IEstoqueSangueRepository>();
            var estoqueMock = new EstoqueSangue("A", "+", 500);
            var listaEstoqueMock = new List<EstoqueSangue> { estoqueMock };

            Guid id = Guid.NewGuid();
            repository.ConsultaTodoEstoqueSangue().Returns(Task.FromResult(listaEstoqueMock));

            var command = new ConsultaTodoEstoqueSangueQuery();

            var handler = new ConsultaTodoEstoqueSangueQueryHandler(repository);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.Sucesso);

        }

        [Fact]
        public async Task Handle_WhenRepositoryReturnsNull_ShouldReturnEmptyList()
        {
            // Arrange
            var estoqueSangueRepositoryMock = Substitute.For<IEstoqueSangueRepository>();
            estoqueSangueRepositoryMock.ConsultaTodoEstoqueSangue().Returns(Task.FromResult<List<EstoqueSangue>>(null));

            var handler = new ConsultaTodoEstoqueSangueQueryHandler(estoqueSangueRepositoryMock);
            var query = new ConsultaTodoEstoqueSangueQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result.Dados);  // Verifica que a lista retornada está vazia
            Assert.True(result.Sucesso); // Verifica que o resultado foi bem-sucedido
            Assert.Equal("", result.Mensagem); // Verifica que a mensagem está vazia
        }

        [Fact]
        public async Task Handle_WhenRepositoryReturnsData_ShouldReturnListWithData()
        {
            // Arrange
            var estoqueSangueRepositoryMock = Substitute.For<IEstoqueSangueRepository>();
            var estoquesangue1 = new EstoqueSangue("+", "A",100);
            var estoquesangue2 = new EstoqueSangue("-", "A",100);
            var estoqueSangueList = new List<EstoqueSangue>
        {
            estoquesangue1,
            estoquesangue2
        };
            estoqueSangueRepositoryMock.ConsultaTodoEstoqueSangue().Returns(Task.FromResult(estoqueSangueList));

            var handler = new ConsultaTodoEstoqueSangueQueryHandler(estoqueSangueRepositoryMock);
            var query = new ConsultaTodoEstoqueSangueQuery();

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result.Dados);  // Verifica que a lista retornada não está vazia
            Assert.True(result.Sucesso);    // Verifica que o resultado foi bem-sucedido
            Assert.Equal("", result.Mensagem); // Verifica que a mensagem está vazia
            Assert.Equal(2, result.Dados.Count); // Verifica que a lista tem 2 itens
        }

        //[Fact]
        //public async Task ConsultaFeitoComErro_NSubistitute()
        //{
        //    //Arrange

        //    var repository = Substitute.For<IEstoqueSangueRepository>();
        //    Guid id = Guid.NewGuid();

        //    List<EstoqueSangue> listadoacaoMock = null;

        //    repository.ConsultaTodoEstoqueSangue().Returns(Task.FromResult(listadoacaoMock));

        //    var command = new ConsultaTodoEstoqueSangueQuery();

        //    var handler = new ConsultaTodoEstoqueSangueQueryHandler(repository);

        //    // Act 
        //    var exception = await Assert.ThrowsAsync<ArgumentException>(
        //        async () => await handler.Handle(command, new CancellationToken())
        //    );

        //    //Assert
        //    Assert.Contains("Estoque de Sangue não encontrado", exception.Message);
        //}
    }
}
