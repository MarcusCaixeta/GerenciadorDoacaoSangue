using GerenciadorDoacaoSangue.Application.InputModels;
using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Application.Queries.DoacaoQuery.ConsultaTodasDoacoesQuery
{
    public class ConsultaTodasDoacoesQueryHandler : IRequestHandler<ConsultaTodasDoacoesQuery, ResponseResult<List<Doacao>>>
    {
        private IDoacaoRepository _repository;

        public ConsultaTodasDoacoesQueryHandler(IDoacaoRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseResult<List<Doacao>>> Handle(ConsultaTodasDoacoesQuery request, CancellationToken cancellationToken)
        {
            var doacoes = await _repository.ConsultaTodasDoacoes();

            return new ResponseResult<List<Doacao>>(doacoes);

        }
    }
}
