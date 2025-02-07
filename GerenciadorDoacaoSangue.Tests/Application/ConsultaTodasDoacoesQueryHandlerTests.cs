using GerenciadorDoacaoSangue.Application.Commands.DoadorCommand.CadastrarDoadorCommand;
using GerenciadorDoacaoSangue.Application.Queries.DoacaoQuery.ConsultaTodasDoacoesQuery;
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
    public class ConsultaTodasDoacoesQueryHandlerTests
    {
        [Fact]
        public async Task ConsultaFeitoComSucesso_NSubistitute()
        {
            //Arrange

            var repository = Substitute.For<IDoacaoRepository>();
            Guid id = Guid.NewGuid();

            var doacaoMock = new Doacao(id, DateTime.Now.AddDays(-300), 280);
            List<Doacao> listadoacaoMock = new List<Doacao> { doacaoMock};

            repository.ConsultaTodasDoacoes().Returns(Task.FromResult(listadoacaoMock));

            var command = new ConsultaTodasDoacoesQuery();
            

            var handler = new ConsultaTodasDoacoesQueryHandler(repository);

            //Act
            var result = await handler.Handle(command, new CancellationToken());

            //Assert
            Assert.True(result.Sucesso);
        }

        //[Fact]
        //public async Task ConsultaFeitoComNull_NSubistitute()
        //{
        //    //Arrange

        //    var repository = Substitute.For<IDoacaoRepository>();
        //    Guid id = Guid.NewGuid();

        //    List<Doacao> listadoacaoMock = new List<Doacao>();

        //    repository.ConsultaTodasDoacoes().Returns(Task.FromResult(listadoacaoMock));

        //    var command = new ConsultaTodasDoacoesQuery();


        //    var handler = new ConsultaTodasDoacoesQueryHandler(repository);

        //    //Act
        //    var result = await handler.Handle(command, new CancellationToken());

        //    //Assert
        //    Assert.False(result.Sucesso);
        //}
    }
}
