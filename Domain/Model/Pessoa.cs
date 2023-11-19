namespace Domain.Model
{
    public class Pessoa
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Cpf { get; protected set; }

        public Pessoa()
        {
        }

        public Pessoa(int id, string nome, string cpf)
        {
            Id = id;
            Nome = nome;
            Cpf = cpf;
        }
    }
}
