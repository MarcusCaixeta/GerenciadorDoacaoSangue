using GerenciadorDoacaoSangue.Core.Entities;
using GerenciadorDoacaoSangue.Core.Repositories;
using GerenciadorDoacaoSangue.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDoacaoSangue.Infrastructure.Repositories
{
    public class DoacaoRepository : IDoacaoRepository
    {
        private readonly GerenciadorDoacaoSangueDbContext _dbContext;

        public DoacaoRepository(GerenciadorDoacaoSangueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public class NotFoundException : Exception
        {
            public NotFoundException(string message) : base(message) { }
        }

        public async Task ProcessarDoacao(Doacao doacao)
        {
            var doador = await _dbContext.Doador.SingleOrDefaultAsync(p => p.Id == doacao.DoadorId);

            if (doador == null)
            {
                throw new NotFoundException("Doador não encontrado");
            }
            else
            {
                await _dbContext.Doacao.AddAsync(doacao);

                var estoqueSangue = await _dbContext.EstoqueSangue.SingleOrDefaultAsync(p => p.TipoSanguineo == doador.TipoSanguineo && p.FatorRh == doador.FatorRh);

                if (estoqueSangue != null)
                {
                    estoqueSangue.QuantidadeML = estoqueSangue.QuantidadeML + doacao.QuantidadeML;

                    _dbContext.EstoqueSangue.Update(estoqueSangue);
                }
                else
                {
                    var novoEstoqueSangue = new EstoqueSangue(doador.TipoSanguineo, doador.FatorRh, doacao.QuantidadeML);
                    await _dbContext.EstoqueSangue.AddAsync(novoEstoqueSangue);

                }

                await _dbContext.SaveChangesAsync();
            }
        }

        public Task<List<Doacao>> ConsultaTodasDoacoes()
        {
            var doacoes = _dbContext.Doacao.ToListAsync();            

            return doacoes;
        }
    }
}
