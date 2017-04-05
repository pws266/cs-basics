namespace CSharpBasics.src
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Xml.Serialization;

    // Serializer for computation result saving
    [XmlRoot("results")]
    public class OutputData
    {
        [XmlElement("output", typeof(OperandElement))]
        public List<InputElement> OutputElements { get; set; }

        public OutputData()
        {
            OutputElements = new List<InputElement>();
        }

        // performs computation results serialization to specified *.xml file
        public static bool SaveToXML(string fileName, OutputData data)
        {
            bool serializationResult = true;

            var writer = new XmlSerializer(typeof(OutputData));

            // deleting all schema info from root tag
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            FileStream fs = null;

            try
            {
                fs = new FileStream(fileName, FileMode.Create);
            }
            catch (IOException exc)
            {
                Interface.DisplayMessage("Error in OutputData->SaveToXML: Unable to open file \"" +
                                         fileName + "\"", ConsoleColor.Yellow, ConsoleColor.Red);
                Interface.DisplayMessage("Description: " + exc, ConsoleColor.Yellow, ConsoleColor.Blue);

                return false;
            }

            var stream = new StreamWriter(fs, Encoding.UTF8);

            try
            {
                writer.Serialize(stream, data, ns);
                stream.Flush();
            }
            catch (IOException exc)
            {
                Interface.DisplayMessage("Error in OutputData->SaveToXML: I/O error while " +
                                         "serializing data to file \"" + fileName + "\"",
                                         ConsoleColor.Yellow, ConsoleColor.Red);
                Interface.DisplayMessage("Description: " + exc, ConsoleColor.Yellow,
                                         ConsoleColor.Blue);

                serializationResult = false;
            }
            finally
            {
                stream.Close();
            }

            return serializationResult;
        }
    }
}
