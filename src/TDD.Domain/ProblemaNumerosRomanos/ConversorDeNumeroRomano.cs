namespace TDD.Domain.ProblemaNumerosRomanos;

public class ConversorDeNumeroRomano
{
    private static readonly Dictionary<string, int> Tabela = new()
    {
        { "I", 1 },
        { "V", 5 },
        { "X", 10 },
        { "L", 50 },
        { "C", 100 },
        { "D", 500 },
        { "M", 1000 }
    };

    public int Converte(string numeroEmRomano)
    {
        var acumulador = 0;
        var ultimoVizinhoDaDireita = 0;
        for (var i = numeroEmRomano.Length - 1; i >= 0; i--)
        {
            var atual = Tabela[numeroEmRomano[i].ToString()];
            var multiplicador = 1;

            if (atual < ultimoVizinhoDaDireita)
                multiplicador = -1;

            acumulador += atual * multiplicador;

            ultimoVizinhoDaDireita = atual;
        }

        return acumulador;
    }
}