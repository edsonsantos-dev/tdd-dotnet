namespace TDD.Domain.ProblemaProcessadorDeBoleto;

public class Fatura
{
    public string Cliente { get; private set; }
    public double Valor { get; private set; }
    public IList<Pagamento> Pagamentos { get; private set; }
    public bool Pago { get; private set; }
    
    public Fatura(string cliente, double valor)
    {
        Cliente = cliente;
        Valor = valor;
        Pagamentos = new List<Pagamento>();
        Pago = false;
    }

    public void AdicionaPagamento(Pagamento pagamento)
    {
        Pagamentos.Add(pagamento);
        var valorTotal = Pagamentos.Sum(p => p.Valor);

        if (valorTotal >= Valor)
            Pago = true;
    }
}