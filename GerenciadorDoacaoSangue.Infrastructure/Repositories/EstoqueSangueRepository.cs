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
    public class EstoqueSangueRepository : IEstoqueSangueRepository
    {
        private readonly GerenciadorDoacaoSangueDbContext _dbContext;

        public EstoqueSangueRepository(GerenciadorDoacaoSangueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EstoqueSangue>?> ConsultaTodoEstoqueSangue()
        {
            var estoqueSangue = await _dbContext.EstoqueSangue.ToListAsync();

            if (estoqueSangue == null)
                throw new NotFoundException("Estoque de Sangue não encontrado");

            return estoqueSangue;
        }
    }
}
