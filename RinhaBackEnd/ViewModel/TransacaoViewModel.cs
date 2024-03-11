using RinhaBackEnd.Models.Client;

namespace RinhaBackEnd.Input;

public class TransacaoViewModel
{
   public int Valor { get; set; }

   public string Tipo { get; set; }

   public string Descricao { get; set; }

   public Transacao CriarTransacao(int id)
   {
      return new Transacao(id, Valor, Tipo, Descricao);
   }
}