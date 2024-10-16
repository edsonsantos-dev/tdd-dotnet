using TDD.Domain.ProblemaCarrinhoCompras;

namespace TDD.NUnit.ProblemaCarrinhoCompras;

public class CarrinhoDeComprasBuilder
{
    public static CarrinhoDeCompras Build(params (string descricao, int quantidade, double valor)[] itens)
    {
        var carrinho = new CarrinhoDeCompras();
        foreach (var item in itens)
            carrinho.Adiciona(new Item(item.descricao, item.quantidade, item.valor));

        return carrinho;
    }
}