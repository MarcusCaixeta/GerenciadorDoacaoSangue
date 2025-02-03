using GerenciadorDoacaoSangue.Application.Commands.DoacaoCommands.ProcessaDoacaoCommand;
using GerenciadorDoacaoSangue.Application.Commands.DoadorCommand.CadastrarDoadorCommand;
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
    public class ProcessaDoacaoCommandHandlerTests
    {

        [Fact]
        public async Task CadastroFeitoComSucesso_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IDoacaoRepository>();
            repository.ProcessarDoacao(Arg.Any<Doacao>()).Returns(Task.FromResult(1));

            var command = new ProcessaDoacaoCommand
            {
               DoadorId = Guid.NewGuid(),
               DataDoacao = DateTime.Now,
               QuantidadeML = 1
            };

            var handler = new ProcessaDoacaoCommandHandler(repository);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.Sucesso);

        }
    }
}
