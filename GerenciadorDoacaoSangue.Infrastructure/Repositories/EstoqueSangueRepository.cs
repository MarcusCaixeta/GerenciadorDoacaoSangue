using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using GerenciadorDoacaoSangue.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

            return estoqueSangue;
        }
    }
}