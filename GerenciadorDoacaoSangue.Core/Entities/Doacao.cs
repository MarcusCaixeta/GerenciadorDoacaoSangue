
namespace GerenciadorDoacaoSangue.Core.Entities
{
    public class Doacao : EntidadeBase
    {
        public Doacao(Guid doadorid, DateTime datadoacao, int quantidademl)
        {
            DoadorId = doadorid;
            DataDoacao = datadoacao;
            QuantidadeML = quantidademl;
        }
        private Doacao() { }

        public Guid DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }
    }
}
