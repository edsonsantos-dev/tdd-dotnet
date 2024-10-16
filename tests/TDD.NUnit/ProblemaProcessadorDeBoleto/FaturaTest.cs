using TDD.Domain.ProblemaProcessadorDeBoleto;

namespace TDD.NUnit.ProblemaProcessadorDeBoleto;

[TestFixture]
public class FaturaTest
{
    [Test]
    public void DeveMarcarFaturaComoPagaCasoBoletoUnicoPagueTudo()
    {
        var processador = new ProcessadorDeBoletos();
        var fatura = new Fatura("Cliente", 150.0);
        var boletos = new List<Boleto> { new(150.0) };

        processador.Processa(boletos, fatura);

        Assert.IsTrue(fatura.Pago);
    }

    [Test]
    public void DeveMarcarFaturaComoPagaCasoMuitosBoletosPagueTudo()
    {
        var processador = new ProcessadorDeBoletos();
        var fatura = new Fatura("Cliente", 300.0);
        var boletos = new List<Boleto> { new(100.0), new(200.0) };

        processador.Processa(boletos, fatura);

        Assert.IsTrue(fatura.Pago);
    }

    [Test]
    public void FaturaNaoDeveSerMarcadaComoPagaSeUnicoBoletoNaoCobrirValorTotal()
    {
        var processador = new ProcessadorDeBoletos();
        var fatura = new Fatura("Cliente", 150.0);
        var boletos = new List<Boleto> { new(100.0) };

        processador.Processa(boletos, fatura);

        Assert.IsFalse(fatura.Pago);
    }
    
    [Test]
    public void FaturaNaoDeveSerMarcadaComoPagaSeMuitosBoletosNaoCobrirValorTotal()
    {
        var processador = new ProcessadorDeBoletos();
        var fatura = new Fatura("Cliente", 350.0);
        var boletos = new List<Boleto> { new(100.0), new(100.0) };

        processador.Processa(boletos, fatura);

        Assert.IsFalse(fatura.Pago);
    }
}