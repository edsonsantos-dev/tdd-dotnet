using TDD.Domain.ProblemaCarrinhoCompras;

namespace TDD.NUnit.ProblemaCarrinhoCompras;

[TestFixture]
public class CarrinhoDeComprasTest
{
    private CarrinhoDeCompras _carrinho;

    [SetUp]
    public void Inicializa()
    {
        _carrinho = new CarrinhoDeCompras();
    }

    [TearDown]
    public void Limpar()
    {
        _carrinho.Itens.Clear();
    }

    [Test]
    public void DeveRetornarZeroSeCarrinhoVazio()
    {
        Assert.AreEqual(0.0, _carrinho.MaiorValor(), 0.0001);
    }

    [Test]
    public void DeveRetornarValorDoItemSeCarrinhoCom1Elemento()
    {
        _carrinho = CarrinhoDeComprasBuilder.Build(("Geladeira", 1, 900));

        Assert.AreEqual(900.0, _carrinho.MaiorValor(), 0.0001);
    }

    [Test]
    public void DeveRetornarMaiorValorSeCarrinhoContemMuitosElementos()
    {
        _carrinho = CarrinhoDeComprasBuilder.Build(
            ("Geladeira", 1, 900),
            ("Fogão", 1, 1500.0),
            ("Máquina de Lavar", 1, 750.0)
        );

        Assert.AreEqual(1500.0, _carrinho.MaiorValor(), 0.0001);
    }

    [Test]
    public void DeveAdicionarItens()
    {
        // garante que o carrinho está vazio
        Assert.AreEqual(0, _carrinho.Itens.Count);

        var item = new Item("Geladeira", 1, 900.0);
        _carrinho.Adiciona(item);

        Assert.AreEqual(1, _carrinho.Itens.Count);
        Assert.AreEqual(item, _carrinho.Itens[0]);
    }
}