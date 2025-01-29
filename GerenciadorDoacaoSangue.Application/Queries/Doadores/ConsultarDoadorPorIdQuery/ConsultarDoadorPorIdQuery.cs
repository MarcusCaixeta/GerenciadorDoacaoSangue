using GerenciadorDoacaoSangue.Application.InputModels;
using GerenciadorDoacaoSangue.Application.Models;
using MediatR;

namespace GerenciadorDoacaoSangue.Application.Queries.Doadores.ConsultarDoadorPorIdQuery
{
    public class ConsultarDoadorPorIdQuery : IRequest<ResponseResult<DetalhesDoadorInputModel>>
    {
        public ConsultarDoadorPorIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
