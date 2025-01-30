using GerenciadorDoacaoSangue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Application.InputModels
{
    public class DetalhesDoacaoInputModel(Doacao doacao)
    {
        public Guid DoadorId { get; private set; } = doacao.DoadorId;
        public DateTime DataDoacao { get; private set; } = doacao.DataDoacao;
        public int QuantidadeML { get; private set; } = doacao.QuantidadeML;
    }
}
