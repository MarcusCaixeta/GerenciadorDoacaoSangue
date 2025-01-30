using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Core.Entities
{
    public class EstoqueSangue : EntidadeBase
    {
        public string TipoSanguineo { get;  set; }
        public string FatorRh { get;  set; }
        public int QuantidadeML { get;  set; }

        private EstoqueSangue() { }

        public EstoqueSangue(string tipoSanguineo, string fatorRh, int quantidadeML)
        {
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            QuantidadeML = quantidadeML;
        }
    }
}
