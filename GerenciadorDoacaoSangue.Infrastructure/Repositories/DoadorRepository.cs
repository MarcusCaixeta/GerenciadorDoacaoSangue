using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Infrastructure.Repositories
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly List<Doador> _doador;
        public DoadorRepository()
        {
            _doador = [];
        }

        public Task Cadastrar(Doador doador)
        {
            _doador.Add(doador);

            return Task.CompletedTask;
        }

    
    }
}
