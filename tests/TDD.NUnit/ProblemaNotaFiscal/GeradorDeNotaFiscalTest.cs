using Moq;
using TDD.Domain.ProblemaNotaFiscal;

namespace TDD.NUnit.ProblemaNotaFiscal;

[TestFixture]
public class GeradorDeNotaFiscalTest
{
    [Test]
    public void DeveGerarNFComValorDeImpostoDescontado()
    {
        var nenhumaAcao = new List<IAcaoAposGerarNota>();
        var relogio = new Mock<RelogioDoSistema>();
        var tabela = new Mock<TabelaDoGoverno>();

        tabela.Setup(x => x.ParaValor(1000.0)).Returns(0.06);

        var gerador = new GeradorDeNotaFiscal(nenhumaAcao, relogio.Object, tabela.Object);
        var pedido = new Pedido("Mauricio", 1000, 1);
        var nf = gerador.Gera(pedido);

        Assert.AreEqual(1000 * 0.06, nf.Valor, 0.0001);
    }

    [Test]
    public void DeveInvocarAcaoesPosteriores()
    {
        var dao = new Mock<NFDao>();
        var sap = new Mock<SAP>();
        var relogio = new Mock<RelogioDoSistema>();
        var tabela = new Mock<TabelaDoGoverno>();

        var gerador = new GeradorDeNotaFiscal(
            new List<IAcaoAposGerarNota>
            {
                dao.Object,
                sap.Object
            },
            relogio.Object,
            tabela.Object);
        var pedido = new Pedido("Mauricio", 1000, 1);
        var nf = gerador.Gera(pedido);

        dao.Verify(x => x.Executa(nf));
        sap.Verify(x => x.Executa(nf));
    }

    [Test]
    public void DeveConsultarATabelaParaCalcularValor()
    {
        var tabela = new Mock<TabelaDoGoverno>();
        var relogio = new Mock<RelogioDoSistema>();
        var nenhumaAcao = new List<IAcaoAposGerarNota>();

        tabela.Setup(x => x.ParaValor(1000.0)).Returns(0.06);

        var gerador = new GeradorDeNotaFiscal(nenhumaAcao, relogio.Object, tabela.Object);
        var pedido = new Pedido("Mauricio", 1000.0, 1);
        var nf = gerador.Gera(pedido);

        tabela.Verify(x => x.ParaValor(1000.0));
        Assert.AreEqual(1000.0 * 0.06, nf.Valor, 0.00001);
    }
}