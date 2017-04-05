namespace CSharpBasics.src
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System.Xml.Serialization;

    // Deserializer for calculator arguments
    [XmlRoot("input", Namespace = "")]
    public class InputData
    {
        [XmlElement("operand", typeof(OperandElement), Namespace = "http://calculator")]
        [XmlElement("operation", typeof(OperationElement), Namespace = "http://calculator")]
        public List<InputElement> InputElements { get; set; }

        // reading calculator arguments from specified *.xml
        public static InputData ParseXML(string fileName)
        {
            InputData data;
            var serializer = new XmlSerializer(typeof(InputData));

            FileStream stream = null;

            try
            {
                stream = new FileStream(fileName, FileMode.Open);
                data = (InputData)serializer.Deserialize(stream);
            }
            catch (IOException exc)
            {
                Interface.DisplayMessage("Error in InputData->ParseXML: I/O error while processing " +
                                         "file \"" + fileName + "\"", ConsoleColor.Yellow,
                                         ConsoleColor.Red);
                Interface.DisplayMessage("Description: " + exc, ConsoleColor.Yellow,
                                         ConsoleColor.Blue);

                data = null;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return data;
        }
    }

    class VerifyInputData
    {/*
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
        } */
    }
}
