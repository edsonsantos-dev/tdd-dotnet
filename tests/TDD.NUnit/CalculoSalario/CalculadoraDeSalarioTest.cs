using TDD.Domain.CalculoSalario;

namespace TDD.NUnit.CalculoSalario;

[TestFixture]
public class CalculadoraDeSalarioTest
{
    [Test]
    public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAbaixoDoLimite()
    {
        var calculadora = new CalculadoraDeSalario();
        var desenvolvedor = new Funcionario("Mauricio", 1500.0, Cargo.DESENVOLVEDOR);

        var salario = calculadora.CalculaSalario(desenvolvedor);

        Assert.AreEqual(1500.0 * 0.9, salario, 0.00001);
    }

    [Test]
    public void DeveCalcularSalarioParaDesenvolvedoresComSalarioAcimaDoLimite()
    {
        var calculadora = new CalculadoraDeSalario();
        var desenvolvedor = new Funcionario("Mauricio", 4000.0, Cargo.DESENVOLVEDOR);

        var salario = calculadora.CalculaSalario(desenvolvedor);

        Assert.AreEqual(4000.0 * 0.8, salario, 0.00001);
    }

    [Test]
    public void deveCalcularSalarioParaDBAsComSalarioAbaixoDoLimite()
    {
        var calculadora = new CalculadoraDeSalario();
        var dba = new Funcionario("Mauricio", 500.0, Cargo.DBA);
        
        var salario = calculadora.CalculaSalario(dba);
        
        Assert.AreEqual(500.0 * 0.85, salario, 0.00001);
    }
}