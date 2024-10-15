namespace TDD.Domain.ProblemaNotaFiscal;

public class GeradorDeNotaFiscal(IList<IAcaoAposGerarNota> acoes, IRelogio relogio, ITabela tabela)
{
    public NotaFiscal Gera(Pedido pedido)
    {
        var valor = pedido.ValorTotal * tabela.ParaValor(pedido.ValorTotal);
        
        var nf = new NotaFiscal(
            pedido.Cliente,
            valor,
            relogio.Hoje());

        foreach (var acao in acoes)
            acao.Executa(nf);
        
        return nf;
    }
}