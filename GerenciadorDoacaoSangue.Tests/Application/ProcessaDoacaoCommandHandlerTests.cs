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
        public async Task DoacaoMenorIdade_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IDoacaoRepository>();
            repository.ProcessarDoacao(Arg.Any<Doacao>()).Returns(Task.FromResult(1));

            var command = new ProcessaDoacaoCommand
            {
                DoadorId = Guid.NewGuid(),
                DataDoacao = DateTime.Now,
                QuantidadeML = 1,
                DataNascimento = DateTime.Now.AddYears(-15)
            };

            var handler = new ProcessaDoacaoCommandHandler(repository);

            // Act 
            var exception = await Assert.ThrowsAsync<ArgumentException>(
                async () => await handler.Handle(command, new CancellationToken())
            );

            //Assert
            Assert.Contains("Menores de 18 anos não podem doar", exception.Message);
        }

        [Fact]

        public async Task DoacaoForaDoPeriodoPermitidoFeminino_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IDoacaoRepository>();
            repository.ProcessarDoacao(Arg.Any<Doacao>()).Returns(Task.FromResult(1));

            var command = new ProcessaDoacaoCommand
            {
                DoadorId = Guid.NewGuid(),
                DataDoacao = DateTime.Now,
                QuantidadeML = 1,
                DataNascimento = DateTime.Now.AddYears(-20),
                Genero = "Feminino",
                DataUltimaDoacao = DateTime.Now.AddDays(-59)
            };

            var handler = new ProcessaDoacaoCommandHandler(repository);

            // Act 
            var exception = await Assert.ThrowsAsync<ArgumentException>(
                async () => await handler.Handle(command, new CancellationToken())
            );

            //Assert
            Assert.Contains("Mulheres só podem doar de 90 em 90 dias", exception.Message);
        }
        [Fact]

        public async Task DoacaoForaDaQuantidadeMinimaPermitida_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IDoacaoRepository>();
            repository.ProcessarDoacao(Arg.Any<Doacao>()).Returns(Task.FromResult(1));

            var command = new ProcessaDoacaoCommand
            {
                DoadorId = Guid.NewGuid(),
                DataDoacao = DateTime.Now,
                QuantidadeML = 100,
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

        [Fact]
        public async Task DoacaoForaDaQuantidadeMaximaPermitida_NSubistitute()
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
        [Fact]

        public async Task DoacaoForaDoPeriodoPermitidoOutros_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IDoacaoRepository>();
            repository.ProcessarDoacao(Arg.Any<Doacao>()).Returns(Task.FromResult(1));

            var command = new ProcessaDoacaoCommand
            {
                DoadorId = Guid.NewGuid(),
                DataDoacao = DateTime.Now,
                QuantidadeML = 1,
                DataNascimento = DateTime.Now.AddYears(-20),
                Genero = "Outros",
                DataUltimaDoacao = DateTime.Now.AddDays(-88)
            };

            var handler = new ProcessaDoacaoCommandHandler(repository);

            // Act 
            var exception = await Assert.ThrowsAsync<ArgumentException>(
                async () => await handler.Handle(command, new CancellationToken())
            );

            //Assert
            Assert.Contains("Só podem se doar de 90 em 90 dias", exception.Message);
        }
        [Fact]

        public async Task DoacaoForaDoPeriodoPermitidoMasculino_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IDoacaoRepository>();
            repository.ProcessarDoacao(Arg.Any<Doacao>()).Returns(Task.FromResult(1));

            var command = new ProcessaDoacaoCommand
            {
                DoadorId = Guid.NewGuid(),
                DataDoacao = DateTime.Now,
                QuantidadeML = 1,
                DataNascimento = DateTime.Now.AddYears(-20),
                Genero = "Masculino",
                DataUltimaDoacao = DateTime.Now.AddDays(-59)
            };

            var handler = new ProcessaDoacaoCommandHandler(repository);

            // Act 
            var exception = await Assert.ThrowsAsync<ArgumentException>(
                async () => await handler.Handle(command, new CancellationToken())
            );

            //Assert
            Assert.Contains("Homens só podem doar de 60 em 60 dias", exception.Message);
        }

        [Fact]
        public async Task FeitoComSucesso_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IDoacaoRepository>();
            repository.ProcessarDoacao(Arg.Any<Doacao>()).Returns(Task.FromResult(1));

            var command = new ProcessaDoacaoCommand
            {
                DoadorId = Guid.NewGuid(),
                DataDoacao = DateTime.Now,
                QuantidadeML = 422,
                DataNascimento = DateTime.Now.AddYears(-19)
            };

            var handler = new ProcessaDoacaoCommandHandler(repository);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.Sucesso);

        }
    }
}
