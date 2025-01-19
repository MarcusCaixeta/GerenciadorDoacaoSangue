using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Core.Entities
{
    public class EstoqueSangue : EntidadeBase
    {
        public string TipoSanguineo { get; private set; }
        public string FatorRh { get; private set; }
        public int QuantidadeML { get; private set; }
    }
}
