namespace TDD.Domain.ProblemaNotaFiscal;

public class RelogioDoSistema : IRelogio
{
    public DateTime Hoje() => DateTime.Now;
}