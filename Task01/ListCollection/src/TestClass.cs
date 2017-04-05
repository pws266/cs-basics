namespace CSharpBasics.src
{
    using System;

    // element for list from collection
    public class TestClass
    {
        public int Number {get; private set;}
        public string Message { get; private set; }

        TestClass(int number, string message)
        {
            Number = number;
            Message = message;
        }

        // factory for creating instances
        public static TestClass Factory(int number, string message)
        {
            return new TestClass(number, message);
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
