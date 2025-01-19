using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Core.Entities
{
    public class EntidadeBase
    {
        protected EntidadeBase()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }

    }
}
