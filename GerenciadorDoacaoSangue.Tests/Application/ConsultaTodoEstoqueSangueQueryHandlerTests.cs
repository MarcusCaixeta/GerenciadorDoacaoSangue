using GerenciadorDoacaoSangue.Application.Commands.DoadorCommand.CadastrarDoadorCommand;
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
            var estoqueMock = new EstoqueSangue("A","+",500);
            var listaEstoqueMock = new List<EstoqueSangue>{estoqueMock};

            Guid id = Guid.NewGuid();
            repository.ConsultaTodoEstoqueSangue().Returns(Task.FromResult(listaEstoqueMock));

            var command = new ConsultaTodoEstoqueSangueQuery();

            var handler = new ConsultaTodoEstoqueSangueQueryHandler(repository);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.Sucesso);

        }
    }
}
