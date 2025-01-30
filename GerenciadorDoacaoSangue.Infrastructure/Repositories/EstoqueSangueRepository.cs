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
    public class EstoqueSangueRepository : IEstoqueSangueRepository
    {
        private readonly GerenciadorDoacaoSangueDbContext _dbContext;

        public EstoqueSangueRepository(GerenciadorDoacaoSangueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<EstoqueSangue>?> ConsultaTodoEstoqueSangue()
        {
            var estoqueSangue = _dbContext.EstoqueSangue.ToListAsync();
            return estoqueSangue;
        }
    }
}
