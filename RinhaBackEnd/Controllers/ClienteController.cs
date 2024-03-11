using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RinhaBackEnd.Infra.Context;
using RinhaBackEnd.Input;
using RinhaBackEnd.Models.Client;

namespace RinhaBackEnd.Controllers;

[Route("clientes")]
[ApiController]
public class ClienteController : ControllerBase
{
    private readonly DbContextCfg _ctx;

    public ClienteController(DbContextCfg ctx)
    {
        _ctx = ctx;
    }

    [HttpPost("{id}/transacoes")]
    public async Task<IActionResult> Transacoes(int id, TransacaoViewModel viewModel)
    {
        var cliente = await _ctx.Set<Cliente>().FirstOrDefaultAsync(x => x.Id == id);

        if (cliente == null)
        {
            return NotFound("cliente não Localizado");
        }
        
        string credito = "c".ToLower();
        
        string debito = "d".ToLower();

        string transacao = viewModel.Tipo.ToLower();

        int saldoAtual;

        if (viewModel.Descricao.Length > 10)
        {
            return UnprocessableEntity();
        }

        if (viewModel.Valor <= 0)
        {
            return UnprocessableEntity();
        }

        if (transacao != credito && transacao != debito)
        {
            return UnprocessableEntity();
        }
        
        if (transacao == debito )
        {
            if (viewModel.Valor > cliente.Limite)
            {
                return UnprocessableEntity();
            }
            
            saldoAtual = cliente.Saldo - viewModel.Valor;

            if (saldoAtual < cliente.Limite*(-1))
            {
                return UnprocessableEntity();
            }

            cliente.Saldo = saldoAtual;
        }

        if (transacao == credito )
        {
             saldoAtual = cliente.Saldo + viewModel.Valor;

            cliente.Saldo = saldoAtual;
        }
   
        _ctx.Set<Transacao>().Add(viewModel.CriarTransacao(cliente.Id));

        try
        {
            await _ctx.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            var ex = e.Message;
            return UnprocessableEntity(ex);
        }
      
        
        return Ok(new
        {
            cliente.Limite,
            cliente.Saldo
        });
    }
    
    [HttpGet("{id}/extrato")]
    public async Task<IActionResult> Extrato(int id)
    {
        var cliente =  _ctx.Set<Cliente>().Include(x => x.Transacoes)
            .Where(x => x.Id == id).Select( x  =>  new
        {
            saldo = new
            {
                x.Saldo,
                data_extrato = DateTime.Now,
                x.Limite
            },
            ultimas_transacoes  = x.Transacoes.Select(y => new
            {
                y.Valor,
                y.Tipo,
                y.Descricao,
                y.RealizadoEm
            })
        });
        
        if (!cliente.Any())
        {
            return NotFound("");
        }
        
        return Ok(cliente);
    }
}