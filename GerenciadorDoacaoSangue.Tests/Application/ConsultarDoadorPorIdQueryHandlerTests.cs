using GerenciadorDoacaoSangue.Application.Commands.DoadorCommand.CadastrarDoadorCommand;
using GerenciadorDoacaoSangue.Application.Queries.DoadorQuery.ConsultarDoadorPorIdQuery;
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
    public class ConsultarDoadorPorIdQueryHandlerTests
    {
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
    }
}
