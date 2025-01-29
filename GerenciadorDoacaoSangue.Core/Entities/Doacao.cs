
namespace GerenciadorDoacaoSangue.Core.Entities
{
    public class Doacao : EntidadeBase
    {
        public Doacao(int doadorid, DateTime datadoacao, int quantidademl, Doador doador)
        {
            DoadorId = doadorid;
            DataDoacao = datadoacao;
            QuantidadeML = quantidademl;
            Doador = doador;
        }
        public int DoadorId { get; private set; }
        public DateTime DataDoacao { get; private set; }
        public int QuantidadeML { get; private set; }
        public Doador Doador { get; private set; }
    }
}
