using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using MediatR;

namespace GerenciadorDoacaoSangue.Application.Commands.DoacaoCommands.ProcessaDoacaoCommand
{
    public class ProcessaDoacaoCommandHandler : IRequestHandler<ProcessaDoacaoCommand, ResponseResult<Task>>
    {
        private readonly IDoadorRepository _repository;
        public ProcessaDoacaoCommandHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseResult<Task>> Handle(ProcessaDoacaoCommand request, CancellationToken cancellationToken)
        {
            var doacao = new Doacao(
                            request.DoadorId,
                            request.DataDoacao,
                            request.QuantidadeML);

            await _repository.ProcessarDoacao(doacao);


            return new ResponseResult<Task>(Task.CompletedTask);
        }
    }
}
