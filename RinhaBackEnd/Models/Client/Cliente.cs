using System.ComponentModel.DataAnnotations;
using System.Transactions;

namespace RinhaBackEnd.Models.Client;

public class Cliente
{
    public Cliente(int id, int limite, int saldo)
    {
        Id = id;
        Limite = limite;
        Saldo = saldo;
        new List<Transacao>();
    }

    public int Id { get; set; }

    public int Limite { get; set; }

    public int Saldo { get; set; }

    public ICollection<Transacao> Transacoes { get; set; }
}