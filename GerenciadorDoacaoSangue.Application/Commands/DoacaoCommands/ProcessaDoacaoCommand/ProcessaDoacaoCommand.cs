using GerenciadorDoacaoSangue.Application.Models;
using MediatR;

namespace GerenciadorDoacaoSangue.Application.Commands.DoacaoCommands.ProcessaDoacaoCommand
{
    public class ProcessaDoacaoCommand : IRequest<ResponseResult<Task>>
    {
        public Guid DoadorId { get; set; }
        public DateTime DataDoacao { get; set; }
        public int QuantidadeML { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; } = "Outros";
        public DateTime DataUltimaDoacao { get; set; }

    }
}
