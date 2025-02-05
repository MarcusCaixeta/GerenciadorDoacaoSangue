using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Entities;
using MediatR;

namespace GerenciadorDoacaoSangue.Application.Commands.DoadorCommand.CadastrarDoadorCommand
{
    public class CadastrarDoadorCommand : IRequest<ResponseResult<Guid>>
    {
        public string NomeCompleto { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; } = string.Empty;
        public decimal Peso { get; set; }
        public string TipoSanguineo { get; set; } = string.Empty;
        public string FatorRh { get; set; } = string.Empty;
        public string Logradouro { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public string Cidade { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public string CEP { get; set; } = string.Empty;
    }
}
