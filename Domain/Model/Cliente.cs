namespace Domain.Model;

public class Cliente : Pessoa
{
    public double Saldo { get; private set; }

    public Cliente(int id, string nome, string cpf, double saldo) : base(id, nome, cpf)
    {
        Saldo = saldo;
    }

    public void SetSaldo(double saldo)
    {
        Saldo = saldo;
    }
}