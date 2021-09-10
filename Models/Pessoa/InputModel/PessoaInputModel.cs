namespace MinApi.Models.Pessoa.InputModel
{
    public class PessoaInputModel
    {
        public PessoaInputModel(string email, string senha)
        {
            Email = email;
            Senha = senha;
        }

        public string Email { get; private set; }
        public string Senha { get; private set; }

    }
}