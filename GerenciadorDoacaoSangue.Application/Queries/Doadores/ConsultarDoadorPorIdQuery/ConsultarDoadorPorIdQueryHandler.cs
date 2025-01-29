using GerenciadorDoacaoSangue.Application.InputModels;
using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Application.Queries.Doadores.ConsultarDoadorPorIdQuery
{
    public class ConsultarDoadorPorIdQueryHandler : IRequestHandler<ConsultarDoadorPorIdQuery, ResponseResult<DetalhesDoadorInputModel>>
    {
        private IDoadorRepository _repository;

        public ConsultarDoadorPorIdQueryHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult<DetalhesDoadorInputModel>> Handle(ConsultarDoadorPorIdQuery request, CancellationToken cancellationToken)
        {
            var doador = await _repository.ConsultarPorId(request.Id);

            if (doador is null)
                return new ResponseResult<DetalhesDoadorInputModel>(default, "Não encontrado", false);

            var viewModel = new DetalhesDoadorInputModel(doador);

            return new ResponseResult<DetalhesDoadorInputModel>(viewModel);
        }
    }
}
