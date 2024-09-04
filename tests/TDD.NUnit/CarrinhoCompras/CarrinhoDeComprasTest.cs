using TDD.Domain.CarrinhoCompras;

namespace TDD.NUnit.CarrinhoCompras;

[TestFixture]
public class CarrinhoDeComprasTest
{
    [Test]
    public void DeveRetornarZeroSeCarrinhoVazio()
    {
        var carrinho = new CarrinhoDeCompras();

        Assert.AreEqual(0.0, carrinho.MaiorValor(), 0.0001);
    }

    [Test]
    public void DeveRetornarValorDoItemSeCarrinhoCom1Elemento()
    {
        var carrinho = new CarrinhoDeCompras();
        
        carrinho.Adiciona(new Item("Geladeira", 1, 900));

        Assert.AreEqual(900, carrinho.MaiorValor(), 0.0001);
    }

    [Test]
    public void DeveRetornarMaiorValorSeCarrinhoContemMuitosElementos()
    {
        var carrinho = new CarrinhoDeCompras();
        
        carrinho.Adiciona(new Item("Geladeira", 1, 900));
        carrinho.Adiciona(new Item("Fogão", 1, 1500.0));
        carrinho.Adiciona(new Item("Máquina de Lavar", 1, 750.0));

        Assert.AreEqual(1500.0, carrinho.MaiorValor(), 0.0001);
    }
}