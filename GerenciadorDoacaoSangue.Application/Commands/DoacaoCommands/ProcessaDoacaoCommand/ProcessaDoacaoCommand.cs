using GerenciadorDoacaoSangue.Application.Models;
using MediatR;

namespace GerenciadorDoacaoSangue.Application.Commands.DoacaoCommands.ProcessaDoacaoCommand
{
    public class ProcessaDoacaoCommand : IRequest<ResponseResult<Task>>
    {
        public int DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }
    }
}
