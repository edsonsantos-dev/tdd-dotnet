namespace TDD.Domain.CalculoSalario;

public class CalculadoraDeSalario
{
    private readonly Dictionary<Cargo, EstrategiaCalculoSalario> _tabela = CriaTabela();

    private static Dictionary<Cargo, EstrategiaCalculoSalario> CriaTabela()
    {
        return new Dictionary<Cargo, EstrategiaCalculoSalario>
        {
            { Cargo.DESENVOLVEDOR, new EstrategiaCalculoSalario(3000, 0.8, 0.9) },
            { Cargo.DBA, new EstrategiaCalculoSalario(2500, 0.75, 0.85) },
            { Cargo.TESTADOR, new EstrategiaCalculoSalario(2500, 0.75, 0.85) }
        };
    }

    public double CalculaSalario(Funcionario funcionario)
    {
        var estrategiaSalario = _tabela[funcionario.Cargo];

        return funcionario.Salario > estrategiaSalario.SalarioMaiorQue
            ? funcionario.Salario * estrategiaSalario.PorcentagemMaiorQue
            : funcionario.Salario * estrategiaSalario.PorcentagemMenorQue;
    }
}