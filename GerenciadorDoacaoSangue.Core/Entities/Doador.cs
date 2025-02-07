
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

        public Doador() { }

        public string Nome { get;  set; }
        public string Email { get;  set; }
        public DateTime DataNascimento { get;  set; }
        public string Genero { get;  set; }
        public decimal Peso { get;  set; }
        public string TipoSanguineo { get;  set; }
        public string FatorRh { get;  set; }
        public string Logradouro { get;  set; }
        public string Bairro { get;  set; }
        public string Cidade { get;  set; }
        public string Estado { get;  set; }
        public string CEP { get;  set; }


    }
}
