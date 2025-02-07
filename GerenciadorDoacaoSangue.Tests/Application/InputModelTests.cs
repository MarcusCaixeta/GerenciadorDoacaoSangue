using GerenciadorDoacaoSangue.Application.InputModels;
using GerenciadorDoacaoSangue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Tests.Application
{
    public class InputModelTests
    {
        [Fact]
        public void DeveInicializarPropriedadesCorretamente()
        {
            // Arrange
            var doadorId = Guid.NewGuid();
            var dataDoacao = DateTime.UtcNow;
            var quantidadeML = 450;

            // Criação de uma instância da classe Doacao
            var doacao = new Doacao(doadorId, dataDoacao, quantidadeML);

            // Act
            var detalhesDoacaoInputModel = new DetalhesDoacaoInputModel(doacao);

            // Assert
            Assert.Equal(doadorId, detalhesDoacaoInputModel.DoadorId);
            Assert.Equal(dataDoacao, detalhesDoacaoInputModel.DataDoacao);
            Assert.Equal(quantidadeML, detalhesDoacaoInputModel.QuantidadeML);
        }
    }
}
