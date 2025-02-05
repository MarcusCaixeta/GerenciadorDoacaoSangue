using GerenciadorDoacaoSangue.Application.InputModels;
using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Application.Queries.DoadorQuery.ConsultarDoadorPorIdQuery
{
    public class ConsultarDoadorPorIdQueryHandler : IRequestHandler<ConsultarDoadorPorIdQuery, ResponseResult<DetalhesDoadorInputModel>>
    {
        private readonly IDoadorRepository _repository;

        public ConsultarDoadorPorIdQueryHandler(IDoadorRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult<DetalhesDoadorInputModel>> Handle(ConsultarDoadorPorIdQuery request, CancellationToken cancellationToken)
        {
            var doador = await _repository.ConsultarPorId(request.Id);

            if (doador is null)
                throw new InvalidOperationException("Nenhuma doador encontrado.");

            var viewModel = new DetalhesDoadorInputModel(doador);

            return new ResponseResult<DetalhesDoadorInputModel>(viewModel);
        }
    }
}
