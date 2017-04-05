namespace CSharpBasics.src
{
    using System.Xml.Serialization;

    // supported operation types of calculator and its decorator strings in XML
    public enum OperationType
    {
        [XmlEnum("sum")]
        Sum,
        [XmlEnum("min")]
        Min
    }
}
