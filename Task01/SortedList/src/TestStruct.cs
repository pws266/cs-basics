namespace CSharpBasics.src
{
    using System;

    // element for custom list
    public struct TestStruct
    {
        public int Number;
        public string Message;

        TestStruct(int number, string message)
        {
            Number = number;
            Message = message;
        }

        // factory for structure instances creation
        public static TestStruct Factory(int number, string message)
        {
            return new TestStruct(number, message);
        }

        // comparision operators need for custom list sorting implementation
        public static bool operator >= (TestStruct a, TestStruct b)
        {
            return (a.Number >= b.Number) ? true : false;
        }

        public static bool operator <= (TestStruct a, TestStruct b)
        {
            return (a.Number <= b.Number) ? true : false;
        }

        public static bool operator >(TestStruct a, TestStruct b)
        {
            return (a.Number > b.Number) ? true : false;
        }

        public static bool operator < (TestStruct a, TestStruct b)
        {
            return (a.Number < b.Number) ? true : false;
        }

        public override string ToString()
        {
            return Message;
        }
    }
}
