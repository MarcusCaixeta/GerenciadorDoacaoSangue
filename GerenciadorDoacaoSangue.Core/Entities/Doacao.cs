
namespace GerenciadorDoacaoSangue.Core.Entities
{
    public class Doacao : EntidadeBase
    {
        public Doacao(int doadorid, DateTime datadoacao, int quantidademl)
        {
            DoadorId = doadorid;
            DataDoacao = datadoacao;
            QuantidadeML = quantidademl;
        }
        private Doacao() { }

        public int DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }
    }
}
