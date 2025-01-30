using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Entities;
using MediatR;

namespace GerenciadorDoacaoSangue.Application.Queries.EstoqueSangueQuery.ConsultaTodoEstoqueSangueQuery
{
    public class ConsultaTodoEstoqueSangueQuery : IRequest<ResponseResult<List<EstoqueSangue>>>
    {
    }
}
