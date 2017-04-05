namespace CSharpBasics.src
{
    using System;
    using System.Xml.Serialization;

    // operand representation
    public class OperandElement : InputElement, IXmlSerializable
    {
        public Int32 Value { get; set; }

        // if you want denote your class in *.xml as a field value you should define custom
        // serialization/deserialization operations
        #region Overloaded methods of IXmlSerializable interface

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.ReadStartElement();

            try
            {
                Value = Convert.ToInt32(reader.ReadString(), 10);
                isCorrectValue = true;
            }
            catch (FormatException)
            {
                isCorrectValue = false;
            }
            catch (OverflowException)
            {
                isCorrectValue = false;
            }
            finally
            {
                // should be for reading next tag in *.xml
                reader.ReadEndElement();
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteString(isCorrectValue ? Convert.ToString(Value) : "error");
        }

        #endregion
    }
}
