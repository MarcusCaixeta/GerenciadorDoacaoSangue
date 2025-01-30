using GerenciadorDoacaoSangue.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Application.InputModels
{
    public class DetalhesDoadorInputModel(Doador doador)
    {
        public Guid Id { get; set; } = doador.Id;
        public string Nome { get; private set; } = doador.Nome;
        public string Email { get; private set; } = doador.Email;
        public DateTime DataNascimento { get; private set; } = doador.DataNascimento;
        public string Genero { get; private set; } = doador.Genero;
        public decimal Peso { get; private set; } = doador.Peso;
        public string Logradouro { get; private set; } = doador.Logradouro;
        public string Bairro { get; private set; } = doador.Bairro;
        public string Cidade { get; private set; } = doador.Cidade;
        public string Estado { get; private set; } = doador.Estado;
        public string CEP { get; private set; } = doador.CEP;
        public string TipoSanguineo { get; private set; } = doador.TipoSanguineo;  
        public string FatorRh { get; private set; } = doador.FatorRh;   
    }
}
