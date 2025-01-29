using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using MediatR;

namespace GerenciadorDoacaoSangue.Application.Commands.DoadorCommand.CadastrarDoadorCommand
{
    public class CadastrarDoadorCommandHandler : IRequestHandler<CadastrarDoadorCommand, ResponseResult<Guid>>

    {
        private readonly IDoadorRepository _repository;
        public CadastrarDoadorCommandHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult<Guid>> Handle(CadastrarDoadorCommand request, CancellationToken cancellationToken)
        {
            var doador = new Doador(
                request.NomeCompleto,
                request.Email,
                request.DataNascimento,
                request.Genero,
                request.Peso,
                request.TipoSanguineo,
                request.FatorRh,
                request.Endereco);

            await _repository.Cadastrar(doador);


            return new ResponseResult<Guid>(
                    doador.Id
                );
        }
    }
}
