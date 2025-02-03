using GerenciadorDoacaoSangue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Tests.Core
{
    public class DoadorTests
    {
        [Fact]
        public void CadastrarDoador()
        {
            //Arrange
            var doador = new Doador("", "", DateTime.Now, "", 10, "", "", "", "", "", "", "");

            
            //Act

            //Assert
            Assert.NotNull(doador.TipoSanguineo);
        }
    }
}
