
namespace GerenciadorDoacaoSangue.Application.Models
{
    public class ResponseResult<T>
    {
        public ResponseResult(T dados, string mensagem = "", bool sucesso = true)
        {
            Dados = dados;
            Mensagem = mensagem;
            Sucesso = sucesso;
        }

        public T Dados { get; set; }
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }
    }

    public class ResponseResult
    {
        public ResponseResult(string mensagem = "", bool sucesso = true)
        {
            Mensagem = mensagem;
            Sucesso = sucesso;
        }
        public string Mensagem { get; set; }
        public bool Sucesso { get; set; }

        public static ResponseResult Success() => new();
        public static ResponseResult Failed(string mensagem) => new(mensagem, false);
    }
}
