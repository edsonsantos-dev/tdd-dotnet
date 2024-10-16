namespace TDD.Domain.ProblemaCarrinhoCompras;

public class CarrinhoDeCompras
{
    public IList<Item> Itens { get; private set; }

    public CarrinhoDeCompras()
    {
        Itens = [];
    }

    public void Adiciona(Item item)
    {
        Itens.Add(item);
    }

    public double MaiorValor()
    {
        return Itens
            .Select(c => c.ValorUnitario)
            .OrderDescending()
            .FirstOrDefault();
    }
}