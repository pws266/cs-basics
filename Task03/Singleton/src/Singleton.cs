namespace CSharpBasics.src
{
    using System;

    // singleton pattern based on generics
    public class Singleton<T> where T: class, new()
    {
        private static Singleton<T> instance;  // static singleton instance
        public T Data { get; set; }            // data of parametrized type

        // private constructor for creating instance via "Instance" method
        private Singleton()
        {
            // creating data instance for reference generics type
            Data = new T();
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
}
