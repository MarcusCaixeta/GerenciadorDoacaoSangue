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
    public class DoacaoRapository : IDoacaoRepository
    {
        private readonly GerenciadorDoacaoSangueDbContext _dbContext;

        public DoacaoRapository(GerenciadorDoacaoSangueDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task ProcessarDoacao(Doacao doacao)
        {          
            var doador = await _dbContext.Doador.SingleOrDefaultAsync(p => p.Id == doacao.DoadorId);

            if (doador == null)
            {
                throw new Exception("Doador não encontrado");
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

        public Task<List<Doacao>?> ConsultaTodasDoacoes()
        {
            var doacoes = _dbContext.Doacao.ToListAsync();
            return doacoes;
        }
    }
}
