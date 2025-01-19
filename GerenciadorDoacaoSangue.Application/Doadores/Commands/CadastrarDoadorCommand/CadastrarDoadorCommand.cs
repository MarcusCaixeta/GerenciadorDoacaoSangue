using GerenciadorDoacaoSangue.Application.Models;
using GerenciadorDoacaoSangue.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GerenciadorDoacaoSangue.Application.Doadores.Commands.CadastrarDoadorCommand
{
    public class CadastrarDoadorCommand : IRequest<ResponseResult<Guid>>
    {
        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Genero { get; private set; }
        public decimal Peso { get; private set; }
        public string TipoSanguineo { get; private set; }
        public string FatorRh { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}
