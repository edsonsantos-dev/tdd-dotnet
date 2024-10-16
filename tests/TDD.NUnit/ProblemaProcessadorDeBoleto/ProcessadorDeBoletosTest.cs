using TDD.Domain.ProblemaProcessadorDeBoleto;

namespace TDD.NUnit.ProblemaProcessadorDeBoleto;

[TestFixture]
public class ProcessadorDeBoletosTest
{
    [Test]
    public void DeveProcessarPagamentoViaBoletoUnico()
    {
        var processador = new ProcessadorDeBoletos();
        var fatura = new Fatura("Cliente", 150.0);
        var boletos = new List<Boleto> { new Boleto(150.0) };

        processador.Processa(boletos, fatura);

        Assert.AreEqual(1, fatura.Pagamentos.Count);
        Assert.AreEqual(150.0, fatura.Pagamentos[0].Valor, 0.00001);
    }

    [Test]
    public void DeveProcessarPagamentoViaMuitosBoletos()
    {
        var processador = new ProcessadorDeBoletos();
        var fatura = new Fatura("Cliente", 300.0);
        var boletos = new List<Boleto>
        {
            new(100.0),
            new(200.0)
        };
        
        processador.Processa(boletos, fatura);
        
        Assert.AreEqual(2, fatura.Pagamentos.Count);
        Assert.AreEqual(100.0, fatura.Pagamentos[0].Valor, 0.00001);
        Assert.AreEqual(200.0, fatura.Pagamentos[1].Valor, 0.00001);
    }
}