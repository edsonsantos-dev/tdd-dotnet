using System.Xml.Serialization;

namespace TDD.Domain.ProblemaNotaFiscal;

[XmlRoot("TaxRules")]
public class RegrasFiscais
{
    [XmlElement("Rule")]
    public List<Regra> Regras { get; set; }
}