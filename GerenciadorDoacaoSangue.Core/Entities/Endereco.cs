using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Core.Entities
{
    public class Endereco : EntidadeBase
    {
        
        public string Logradouro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
        public Doador Doador { get; private set; }
    }
}
