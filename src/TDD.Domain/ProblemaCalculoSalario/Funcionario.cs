namespace TDD.Domain.ProblemaCalculoSalario;

public class Funcionario
{
    public string Nome { get; private set; }
    public double Salario { get; private set; }
    public Cargo Cargo { get; private set; }

    public Funcionario(string nome, double salario, Cargo cargo)
    {
        Nome = nome;
        Salario = salario;
        Cargo = cargo;
    }

    public double CalcularSalario()
    {
        var estrategiaCalculo = EstrategiaCalculoSalario.ObterEstrategiaCalculo(Cargo);
        
        return Salario > estrategiaCalculo.SalarioMaiorQue
            ? Salario * estrategiaCalculo.PorcentagemMaiorQue
            : Salario * estrategiaCalculo.PorcentagemMenorQue;
    }
}