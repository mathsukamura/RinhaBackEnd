namespace RinhaBackEnd.Models.Client;

public class Transacao
{
    public Transacao( int idCliente, int valor, string tipo, string descricao)
    {
        IdCliente = idCliente;
        Valor = valor;
        Tipo = tipo;
        Descricao = descricao;
        RealizadoEm = DateTime.UtcNow;
    }
    public int Id { get; set; }

    public int IdCliente { get; set; }

    public int Valor { get; set; }

    public string Tipo { get; set; }

    public string Descricao { get; set; }

    public DateTime RealizadoEm { get; set; }

    public Cliente Cliente { get; set; }
}