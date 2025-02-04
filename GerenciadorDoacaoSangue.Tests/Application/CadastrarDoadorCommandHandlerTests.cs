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
    public class CadastrarDoadorCommandHandlerTests
    {
        [Fact]
        public async Task CadastroFeitoComSucesso_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IDoadorRepository>();
            repository.Cadastrar(Arg.Any<Doador>()).Returns(Task.FromResult(1));

            var command = new CadastrarDoadorCommand
            {
                NomeCompleto = "João da Silva",
                Email = "joao.silva@email.com",
                DataNascimento = new DateTime(1990, 5, 15),
                Genero = "Masculino",
                Peso = 75.5m,
                TipoSanguineo = "O",
                FatorRh = "+",
                Logradouro = "Rua das Flores, 123",
                Bairro = "Centro",
                Cidade = "São Paulo",
                Estado = "SP",
                CEP = "01000-000"
            };

            var handler = new CadastrarDoadorCommandHandler(repository);
         
            //Act
            var resulta = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(resulta.Sucesso);

        }

        [Fact]
        public async Task CadastroErro_PesoMinimo()
        {
            // Arrange
            var repository = Substitute.For<IDoadorRepository>();
            repository.Cadastrar(Arg.Any<Doador>()).Returns(Task.FromResult(1));

            var command = new CadastrarDoadorCommand
            {
                NomeCompleto = "João da Silva",
                Email = "joao.silva@email.com",
                DataNascimento = new DateTime(1990, 5, 15),
                Genero = "Masculino",
                Peso = 45.5m, // Peso abaixo do mínimo (supondo que o mínimo seja 50kg)
                TipoSanguineo = "O",
                FatorRh = "+",
                Logradouro = "Rua das Flores, 123",
                Bairro = "Centro",
                Cidade = "São Paulo",
                Estado = "SP",
                CEP = "01000-000"
            };

            var handler = new CadastrarDoadorCommandHandler(repository);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                async () => await handler.Handle(command, new CancellationToken())
            );

            // Verifica se a mensagem de erro contém a justificativa esperada
            Assert.Contains("Peso mínimo para doação é 50kg", exception.Message);
        }

        //[Fact]
        //public async Task CadastroComEmailDuplicadoErro_NSubistitute()
        //{
        //    //Arrange

        //    var repository = Substitute.For<IDoadorRepository>();
        //    repository.Cadastrar(Arg.Any<Doador>()).Returns(Task.FromResult(1));

        //    var command = new CadastrarDoadorCommand
        //    {
        //        NomeCompleto = "João da Silva",
        //        Email = "joao.silva@email.com",
        //        DataNascimento = new DateTime(1990, 5, 15),
        //        Genero = "Masculino",
        //        Peso = 75.5m,
        //        TipoSanguineo = "O",
        //        FatorRh = "+",
        //        Logradouro = "Rua das Flores, 123",
        //        Bairro = "Centro",
        //        Cidade = "São Paulo",
        //        Estado = "SP",
        //        CEP = "01000-000"
        //    };

        //    var command2 = new CadastrarDoadorCommand
        //    {
        //        NomeCompleto = "Carlos Pereira",
        //        Email = "joao.silva@email.com",
        //        DataNascimento = new DateTime(1985, 8, 22),
        //        Genero = "Masculino",
        //        Peso = 82.3m,
        //        TipoSanguineo = "A",
        //        FatorRh = "-",
        //        Logradouro = "Avenida Paulista, 456",
        //        Bairro = "Bela Vista",
        //        Cidade = "São Paulo",
        //        Estado = "SP",
        //        CEP = "01310-000"
        //    };

        //    var handler = new CadastrarDoadorCommandHandler(repository);

        //    //Act
        //    var result = await handler.Handle(command, new CancellationToken());

        //    var exception = await Assert.ThrowsAsync<ArgumentException>(
        //        async () => await handler.Handle(command2, new CancellationToken())
        //    );

        //    //Assert
        //    Assert.Contains("Email já existe", exception.Message);

        //}
    }
}
