using GerenciadorDoacaoSangue.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Tests.Application
{
    public class ModelsTest
    {
        [Fact]
        public void ResponseResult_WithData_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var dados = Guid.NewGuid();
            var mensagem = "Operação bem-sucedida";
            var sucesso = true;

            // Act
            var responseResult = new ResponseResult<Guid>(dados, mensagem, sucesso);

            // Assert
            Assert.Equal(dados, responseResult.Dados);
            Assert.Equal(mensagem, responseResult.Mensagem);
            Assert.Equal(sucesso, responseResult.Sucesso);
        }

        [Fact]
        public void ResponseResult_DefaultValues_ShouldBeSetCorrectly()
        {
            // Act
            var responseResult = new ResponseResult<Guid>(Guid.Empty);

            // Assert
            Assert.Equal(Guid.Empty, responseResult.Dados);
            Assert.Equal("", responseResult.Mensagem);
            Assert.True(responseResult.Sucesso);
        }
        [Fact]
        public void ResponseResult_Success_ShouldCreateSuccessResult()
        {
            // Act
            var responseResult = ResponseResult.Success();

            // Assert
            Assert.Equal("", responseResult.Mensagem);
            Assert.True(responseResult.Sucesso);
        }

        [Fact]
        public void ResponseResult_Failed_ShouldCreateFailedResultWithMessage()
        {
            // Arrange
            var mensagem = "Erro na operação";

            // Act
            var responseResult = ResponseResult.Failed(mensagem);

            // Assert
            Assert.Equal(mensagem, responseResult.Mensagem);
            Assert.False(responseResult.Sucesso);
        }
    }
}
