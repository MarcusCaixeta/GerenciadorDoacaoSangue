using GerenciadorDoacaoSangue.Application.InputModels;
using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Application.Queries.DoacaoQuery.ConsultaTodasDoacoesQuery
{
    public class ConsultaTodasDoacoesQuery : IRequest<ResponseResult<List<Doacao>>>
    {
    }
}
