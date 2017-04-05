namespace CSharpBasics.src
{
    using System;

    // class for singleton verification
    public class VerifySingleton
    {
        public static void Main()
        {
            Console.Title = "Generic singleton verification";

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
