using GerenciadorDoacaoSangue.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Application.Queries.Doadores.ConsultaDoador
{
    public class ConsultarDoadorCommand : IRequest<Doador>
    {        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Genero { get; private set; }
        public decimal Peso { get; private set; }
        public string TipoSanguineo { get; private set; }
        public string FatorRh { get; private set; }
        public List<Doacao> Doacoes { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}
