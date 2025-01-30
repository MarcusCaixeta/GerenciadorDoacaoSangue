using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Entities;
using MediatR;

namespace GerenciadorDoacaoSangue.Application.Commands.DoadorCommand.CadastrarDoadorCommand
{
    public class CadastrarDoadorCommand : IRequest<ResponseResult<Guid>>
    {
        public string NomeCompleto { get;  set; }
        public string Email { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string Genero { get;  set; }
        public decimal Peso { get;  set; }
        public string TipoSanguineo { get;  set; }
        public string FatorRh { get;  set; }
        public string Logradouro { get;  set; }
        public string Bairro { get;  set; }
        public string Cidade { get;  set; }
        public string Estado { get;  set; }
        public string CEP { get;  set; }
    }
}
