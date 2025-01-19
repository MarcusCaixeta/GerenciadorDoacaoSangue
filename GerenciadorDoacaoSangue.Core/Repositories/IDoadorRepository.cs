using GerenciadorDoacaoSangue.Core.Entities;

namespace GerenciadorDoacaoSangue.Core.Repositories
{
    public interface IDoadorRepository
    {
        Task Cadastrar(Doador doador);
    }
}
