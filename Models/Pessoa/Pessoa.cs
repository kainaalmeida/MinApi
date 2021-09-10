namespace MinApi.Models.Pessoa
{
    public class Pessoa
    {
        public Pessoa(string nome, string email, string senha, string role)
        {
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Role = role;

        }
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public string Role { get; private set; }

        internal void LimparSenha() => Senha = string.Empty;
    }
}