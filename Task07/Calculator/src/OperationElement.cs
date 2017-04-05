namespace CSharpBasics.src
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class OperationElement : InputElement, IXmlSerializable
    {
        private static string OperationToXMLName(OperationType operation)
        {
            return ((XmlEnumAttribute)typeof(OperationType).GetMember(operation.ToString())[0]
                                      .GetCustomAttributes(typeof(XmlEnumAttribute), false)[0])
                                      .Name;
        }

        private static Dictionary<string, OperationType> GetOperationNames()
        {
            var namesList = Enum.GetValues(typeof(OperationType));
            Dictionary<string, OperationType> namesMap = new Dictionary<string, OperationType>();

            foreach (OperationType operationName in namesList)
            {
                namesMap.Add(OperationToXMLName(operationName), operationName);
            }

            return namesMap;
        }

        private static Dictionary<string, OperationType> xmlNameToOperation = GetOperationNames();

        public OperationType Operation { get; set; }

        #region Overloaded methods of IXmlSerializable interface

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {
            reader.MoveToAttribute("operationType");

            try
            {
                Operation = xmlNameToOperation[reader.Value];
                isCorrectValue = true;
            }
            catch (KeyNotFoundException)
            {
                isCorrectValue = false;
            }
            finally
            {
                // should be for reading next tag in *.xml
                reader.Skip();
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("operationType",
                                        isCorrectValue ? OperationToXMLName(Operation) : "error");
        }

        #endregion
    }
}
