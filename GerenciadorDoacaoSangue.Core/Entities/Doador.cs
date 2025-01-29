
namespace GerenciadorDoacaoSangue.Core.Entities
{
    public class Doador : EntidadeBase
    {
        public Doador(string nome, string email, DateTime dataNascimento, string genero, decimal peso, string tipoSanguineo, string fatorRh, Endereco endereco)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            Endereco = endereco;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Genero { get; private set; }
        public decimal Peso { get; private set; }
        public string TipoSanguineo { get; private set; }
        public string FatorRh { get; private set; }
        public List<Doacao> Doacoes{ get; private set; }
        public Endereco Endereco { get; private set; }
    }
}
