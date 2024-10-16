namespace TDD.Domain.ProblemaCalculoSalario;

public class EstrategiaCalculoSalario
{
    public double SalarioMaiorQue { get; private set; }
    public double PorcentagemMaiorQue { get; private set; }
    public double PorcentagemMenorQue { get; private set; }


    public EstrategiaCalculoSalario(
        double salarioMaiorQue,
        double porcentagemMaiorQue,
        double porcentagemMenorQue)
    {
        SalarioMaiorQue = salarioMaiorQue;
        PorcentagemMaiorQue = porcentagemMaiorQue;
        PorcentagemMenorQue = porcentagemMenorQue;
    }

    public static EstrategiaCalculoSalario ObterEstrategiaCalculo(Cargo cargo)
        => EstrategiaCalculo[cargo];

    private static readonly Dictionary<Cargo, EstrategiaCalculoSalario> EstrategiaCalculo = CriaTabela();

    private static Dictionary<Cargo, EstrategiaCalculoSalario> CriaTabela()
    {
        return new Dictionary<Cargo, EstrategiaCalculoSalario>
        {
            { Cargo.DESENVOLVEDOR, new EstrategiaCalculoSalario(3000, 0.8, 0.9) },
            { Cargo.DBA, new EstrategiaCalculoSalario(2500, 0.75, 0.85) },
            { Cargo.TESTADOR, new EstrategiaCalculoSalario(2500, 0.75, 0.85) }
        };
    }
}