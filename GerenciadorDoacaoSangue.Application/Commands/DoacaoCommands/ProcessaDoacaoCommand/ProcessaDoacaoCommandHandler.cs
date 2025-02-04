using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using MediatR;

namespace GerenciadorDoacaoSangue.Application.Commands.DoacaoCommands.ProcessaDoacaoCommand
{
    public class ProcessaDoacaoCommandHandler : IRequestHandler<ProcessaDoacaoCommand, ResponseResult<Task>>
    {
        private readonly IDoacaoRepository _repository;
        public ProcessaDoacaoCommandHandler(IDoacaoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseResult<Task>> Handle(ProcessaDoacaoCommand request, CancellationToken cancellationToken)
        {
            
            if (DateTime.Now.Year - request.DataNascimento.Year <= 18)
                throw new ArgumentException("Menores de 18 anos não podem doar");
            if (request.Genero == "Feminino" && request.DataUltimaDoacao >= DateTime.Now.AddDays(-90))
                throw new ArgumentException("Mulheres só podem doar de 90 em 90 dias");
            if (request.Genero == "Masculino" && request.DataUltimaDoacao >= DateTime.Now.AddDays(-60))
                throw new ArgumentException("Homens só podem doar de 60 em 60 dias");
            if (request.Genero == "Outros" && request.DataUltimaDoacao >= DateTime.Now.AddDays(-90))
                throw new ArgumentException("Só podem se doar de 90 em 90 dias");
            if (request.QuantidadeML < 420 || request.QuantidadeML > 470)
                throw new ArgumentException("Quantidade fora do permitido");

            var doacao = new Doacao(
                            request.DoadorId,
                            request.DataDoacao,
                            request.QuantidadeML);

            await _repository.ProcessarDoacao(doacao);


            return new ResponseResult<Task>(Task.CompletedTask);
        }
    }
}
