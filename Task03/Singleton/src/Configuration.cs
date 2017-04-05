namespace CSharpBasics.src
{
    using System;

    // reference type for singleton testing
    public class Configuration
    {
        public int PortNumber = 8080;
        public string IP = "192.168.175.100";
        public string ServerName = "api.tensorflow.amazon.com";

        public Configuration()
        {
        }

        public override string ToString()
        {
            return String.Format("Current configuration:\nPort number: {0}\nIP address: {1}\n" +
                                 "Server name: {2}", PortNumber, IP, ServerName);
        }
    }
}
