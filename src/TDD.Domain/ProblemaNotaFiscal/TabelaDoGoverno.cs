using System.Xml.Serialization;

namespace TDD.Domain.ProblemaNotaFiscal;

public class TabelaDoGoverno : ITabela
{
    public virtual double ParaValor(double valor)
    {
        var regrasFiscais = CarregarRegrasFiscais();

        if (regrasFiscais is null)
            return 0;
        
        var regra = ObterRegra(regrasFiscais.Regras, valor);

        return regra?.Rate ?? 0;
    }

    private RegrasFiscais? CarregarRegrasFiscais()
    {
        var filePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "ProblemaNotaFiscal",
            "TaxRules.xml");
        
        var serializer = new XmlSerializer(typeof(RegrasFiscais));
        using var fs = new FileStream(filePath, FileMode.Open);
        
        return (RegrasFiscais)serializer.Deserialize(fs);
    }
    
    private Regra? ObterRegra(IEnumerable<Regra> rules, double valor) =>
        rules.FirstOrDefault(rule => valor >= rule.Min && valor <= rule.Max);
}