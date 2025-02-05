using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using GerenciadorDoacaoSangue.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GerenciadorDoacaoSangue.Infrastructure.Repositories.DoacaoRapository;

namespace GerenciadorDoacaoSangue.Infrastructure.Repositories
{
    public class DoadorRepository : IDoadorRepository
    {
        private readonly GerenciadorDoacaoSangueDbContext _dbContext;

        public DoadorRepository(GerenciadorDoacaoSangueDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        public async Task Cadastrar(Doador doador)
        {
            var doadorValidacaoEmail = await _dbContext.Doador.SingleOrDefaultAsync(p => p.Email == doador.Email);
            if (doadorValidacaoEmail != null)
                throw new ArgumentException("Email já existe");

            await _dbContext.Doador.AddAsync(doador);

            await _dbContext.SaveChangesAsync();

        }

        public async Task<Doador> ConsultarPorId(Guid id)
        {
            var doador = await _dbContext.Doador.SingleOrDefaultAsync(p => p.Id == id);
            
            if (doador == null)
                throw new NotFoundException("Doador não encontrado");

            return doador;
        }
    }
}
