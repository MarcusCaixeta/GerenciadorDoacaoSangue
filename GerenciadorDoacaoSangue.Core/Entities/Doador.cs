
namespace GerenciadorDoacaoSangue.Core.Entities
{
    public class Doador : EntidadeBase
    {
        public Doador(string nome, string email, DateTime dataNascimento, string genero, decimal peso, string tipoSanguineo, string fatorRh, string logradouro,
            string bairro, string cidade, string estado, string cep)
        {
            Nome = nome;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;

            ArgumentOutOfRangeException.ThrowIfLessThan(peso, 50);
            Peso = peso;

            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            Logradouro = logradouro;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }

        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Genero { get; private set; }
        public decimal Peso { get; private set; }
        public string TipoSanguineo { get; private set; }
        public string FatorRh { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }


    }
}
