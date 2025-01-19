using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Application.Doadores.Commands.CadastrarDoadorCommand
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
