using TDD.Domain.NumerosRomanos;

namespace TDD.NUnit.NumerosRomanos;

[TestFixture]
public class ConversorDeNumeroRomanoTest
{
    [Test]
    public void DeveEntenederOSimboloI()
    {
        var romano = new ConversorDeNumeroRomano();
        var numero = romano.Converte("I");
        Assert.AreEqual(1, numero);
    }

    [Test]
    public void DeveEntenederOSimboloV()
    {
        var romano = new ConversorDeNumeroRomano();
        var numero = romano.Converte("V");
        Assert.AreEqual(5, numero);
    }

    [Test]
    public void DeveEntenederOSimboloII()
    {
        var romano = new ConversorDeNumeroRomano();
        var numero = romano.Converte("II");
        Assert.AreEqual(2, numero);
    }

    [Test]
    public void DeveEntenderQuatroSimbolosDoisADoisComoXXII()
    {
        var romano = new ConversorDeNumeroRomano();
        var numero = romano.Converte("XXII");
        Assert.AreEqual(22, numero);
    }
    
    [Test]
    public void DeveEntenderNumerosComoIX()
    {
        ConversorDeNumeroRomano romano =
            new ConversorDeNumeroRomano();
        int numero = romano.Converte("IX");
        Assert.AreEqual(9, numero);
    }
    
    [Test]
    public void DeveEntenderNumerosComplexosComoXXIV()
    {
        ConversorDeNumeroRomano romano =
            new ConversorDeNumeroRomano();
        int numero = romano.Converte("XXIV");
        Assert.AreEqual(24, numero);
    }
}