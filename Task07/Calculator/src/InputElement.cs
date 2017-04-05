namespace CSharpBasics.src
{
    using System.Xml.Serialization;

    // description of list element for operand/operation storing
    [XmlIncludeAttribute(typeof(OperandElement))]
    [XmlIncludeAttribute(typeof(OperationElement))]
    public abstract class InputElement
    {
        public bool isCorrectValue = true;    // flag notifying if element was read/written correctly
    }
}
