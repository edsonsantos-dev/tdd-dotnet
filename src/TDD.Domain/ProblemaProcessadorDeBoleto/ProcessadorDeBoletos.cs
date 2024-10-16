namespace TDD.Domain.ProblemaProcessadorDeBoleto;

public class ProcessadorDeBoletos
{
    public void Processa(IList<Boleto> boletos, Fatura fatura)
    {
        foreach (var boleto in boletos)
        {
            var pagamento = new Pagamento(boleto.Valor, MeioDePagamento.Boleto);
            fatura.AdicionaPagamento(pagamento);
        }
    }
}