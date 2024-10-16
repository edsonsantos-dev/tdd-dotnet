using TDD.Domain.ProblemaCalculoSalario;

namespace TDD.NUnit.ProblemaCalculoSalario;

[TestFixture]
public class CalculadoraDeSalarioTest
{
    [Test]
    public void DeveCalcularSalarioDoLimiteComDezPorcentoDeDesconto()
    {
        var desenvolvedor = new Funcionario("Mauricio", 1500.0, Cargo.DESENVOLVEDOR);

        var salario = desenvolvedor.CalcularSalario();

        Assert.AreEqual(1500.0 * 0.9, salario, 0.00001);
    }

    [Test]
    public void DeveCalcularSalarioAcimaDoLimiteComVintePorcentoDeDesconto()
    {
        var desenvolvedor = new Funcionario("Mauricio", 4000.0, Cargo.DESENVOLVEDOR);

        var salario = desenvolvedor.CalcularSalario();

        Assert.AreEqual(4000.0 * 0.8, salario, 0.00001);
    }

    [Test]
    public void DeveCalcularSalarioAbaixoDoLimiteComQuinzePorcentoDeDesconto()
    {
        var dba = new Funcionario("Mauricio", 500.0, Cargo.DBA);

        var salario = dba.CalcularSalario();

        Assert.AreEqual(500.0 * 0.85, salario, 0.00001);
    }
    
    
    [Test]
    public void DeveCalcularSalarioAcimaDoLimiteComVinteEhCincoPorcentoDeDesconto()
    {
        var desenvolvedor = new Funcionario("Mauricio", 4000.0, Cargo.TESTADOR);

        var salario = desenvolvedor.CalcularSalario();

        Assert.AreEqual(4000.0 * 0.75, salario, 0.00001);
    }
}