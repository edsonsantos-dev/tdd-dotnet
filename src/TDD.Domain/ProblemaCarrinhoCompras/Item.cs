namespace TDD.Domain.ProblemaCarrinhoCompras;

public class Item
{
    public string Descricao { get; private set; }
    public int Quantidade { get; private set; }
    public double ValorUnitario { get; private set; }

    public Item(string descricao, int quantidade, double valorUnitario)
    {
        Descricao = descricao;
        Quantidade = quantidade;
        ValorUnitario = valorUnitario;
    }

    public double ValorTotal => Quantidade * ValorUnitario;
}