using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Application.Queries.EstoqueSangueQuery.ConsultaTodoEstoqueSangueQuery
{
    public class ConsultaTodoEstoqueSangueQueryHandler : IRequestHandler<ConsultaTodoEstoqueSangueQuery, ResponseResult<List<EstoqueSangue>>>
    {
        private readonly IEstoqueSangueRepository _repository;

        public ConsultaTodoEstoqueSangueQueryHandler(IEstoqueSangueRepository repository)
        {
            _repository = repository;
        }
        public async Task<ResponseResult<List<EstoqueSangue>>> Handle(ConsultaTodoEstoqueSangueQuery request, CancellationToken cancellationToken)
        {
            var estoqueSangue = await _repository.ConsultaTodoEstoqueSangue();

            if (estoqueSangue is null)
                return new ResponseResult<List<EstoqueSangue>>([]);

            return new ResponseResult<List<EstoqueSangue>>(estoqueSangue);
        }
    }
}
