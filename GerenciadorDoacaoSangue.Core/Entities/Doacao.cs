using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Core.Entities
{
    public class Doacao : EntidadeBase
    {
        public int DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }
        public Doador Doador { get; private set; }
    }
}
