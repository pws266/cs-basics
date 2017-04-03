using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CSharpBasics
{
    [XmlRoot("input", Namespace = "")]
    public class InputData
    {
        [XmlElement("operand", typeof(OperandElement), Namespace = "http://calculator")]
        [XmlElement("operation", typeof(OperationElement), Namespace = "http://calculator")]
        public List<InputElement> InputElements { get; set; }
    }

    [XmlIncludeAttribute(typeof(OperandElement))]
    [XmlIncludeAttribute(typeof(OperationElement))]
    public abstract class InputElement
    {

    }

    public class OperandElement : InputElement, IXmlSerializable
    {
        public Int32 Value { get; set; }

        #region Overloaded methods of IXmlSerializable interface

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadStartElement();
            Value = Convert.ToInt32(reader.ReadString(), 10);
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteString(Convert.ToString(Value));
        }

        #endregion
    }

    public class OperationElement : InputElement
    {
        [XmlAttribute("operationType")]
        public OperationType Operation { get; set; }
    }

    public enum OperationType
    {
        [XmlEnum("sum")]
        Sum,
        [XmlEnum("min")]
        Min
    }

    class VerifyInputData
    {
        public static void Main()
        {
            InputData inData = new InputData();
            inData.InputElements = new List<InputElement>()
            {
                new OperandElement() {Value = 10},
                new OperationElement() {Operation = OperationType.Sum},
                new OperandElement() {Value = 25},
            };

            var writer = new XmlSerializer(typeof(InputData));

            var ns = new XmlSerializerNamespaces();
            ns.Add("calc", "http://calculator");

            using (var stream = new StreamWriter(new FileStream("../../../files/NewInputData.xml", FileMode.Create), Encoding.UTF8))
            {
                writer.Serialize(stream, inData, ns);
                stream.Flush();
            }

            InputData id = new InputData();
            var serializer = new XmlSerializer(typeof(InputData));

            using (var stream = new FileStream("../../../files/NewInputData.xml", FileMode.Open))
            {
                id = (InputData)serializer.Deserialize(stream);
            }

            int elementCounter = 0;

            OperandElement operand = null;
            OperationElement operation = null;

            foreach (InputElement ie in id.InputElements)
            {
                if (elementCounter % 3 == 1)
                {
                    operation = (OperationElement)ie;
                    Console.WriteLine("Operation: " + operation.Operation);
                }
                else
                {
                    operand = (OperandElement)ie;
                    Console.WriteLine("Operand: " + operand.Value);
                }

                ++elementCounter;
            }
        } 
    }
}
