namespace TDD.Domain.ProblemaProcessadorDeBoleto;

public class Pagamento
{
    public double Valor { get; private set; }
    public MeioDePagamento MeioDePagamento { get; private set; }

    public Pagamento(double valor, MeioDePagamento meioDePagamento)
    {
        Valor = valor;
        MeioDePagamento = meioDePagamento;
    }
}