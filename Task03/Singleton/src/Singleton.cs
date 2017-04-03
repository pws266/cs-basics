using System;

namespace CSharpBasics
{
    // singleton pattern based on generics
    public class Singleton<T> where T: new()
    {
        private static Singleton<T> instance;  // static singleton instance
        public T Data { get; set; }            // data of parametrized type

        // private constructor for creating instance via "Instance" method
        private Singleton()
        {
            if (!typeof(T).IsValueType)
            {
                // creating data instance for reference generics type
                Data = new T();
            }
        }

        // returns reference to created singleton
        public static Singleton<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    // lock to prevent two singleton instances creation in different threads
                    lock (typeof(Singleton<T>))
                    {
                        if (instance == null)
                            instance = new Singleton<T>();
                    }
                }
                return instance;
            }
        }

        // displays data content using overloaded method "ToString" for reference type
        public void PrintData()
        {
            Console.WriteLine(Data);
        }
    }

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

    // singleton verification
    class VerifySingleton
    {
        public static void Main()
        {
            // verification for value type
            Singleton<int> stInt = Singleton<int>.Instance;

            Console.Write("Default \"integer\" value: ");
            stInt.PrintData();

            stInt.Data = 15;
            Console.Write("Assigned \"integer\" value: ");
            stInt.PrintData();

            Singleton<int> stInt1 = Singleton<int>.Instance;

            stInt1.Data = 25;
            Console.Write("Assigned \"integer\" value from another reference: ");
            stInt.PrintData();

            // verification for reference type
            Singleton<Configuration> stCfg = Singleton<Configuration>.Instance;
            Console.WriteLine("\nDefault \"Configuration\" value: ");
            stCfg.PrintData();

            Singleton<Configuration> stCfg1 = Singleton<Configuration>.Instance;
            stCfg1.Data.IP = "172.50.80.77";
            stCfg1.Data.ServerName = "recognize.clarifai.com";

            Console.WriteLine("\nChanged \"Configuration\" value from another reference: ");
            stCfg.PrintData();
        }
    }
}
