using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using GerenciadorDoacaoSangue.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDoacaoSangue.Infrastructure.Repositories
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly GerenciadorDoacaoSangueDbContext _dbContext;

        public DoadorRepository(GerenciadorDoacaoSangueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private readonly List<Doador> _doador;
        public DoadorRepository()
        {
            _doador = [];
        }

        public async Task Cadastrar(Doador doador)
        {
            var doadorValidacaoEmail = await _dbContext.Doador.SingleOrDefaultAsync(p => p.Email == doador.Email);
            if (doadorValidacaoEmail != null)
                throw new ArgumentException("Email já existe");

            var id = await _dbContext.Doador.AddAsync(doador);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<Doador> ConsultarPorId(Guid Id)
        {
            return await _dbContext.Doador.SingleOrDefaultAsync(p => p.Id == Id);
        }
    }
}
