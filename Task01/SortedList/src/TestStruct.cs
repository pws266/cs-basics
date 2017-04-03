using System;

namespace CSharpBasics
{
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
/*
    class TestStructVerification
    {
        public static void Main()
        {
            TestStruct a = TestStruct.Fabric(10, "Struct A");

            TestStruct b = a;

            if (a.Equals(b))
            {
                Console.WriteLine("A and B have the same number values");
            }

            b.Number = 20;

            if (!a.Equals(b))
            {
                Console.WriteLine("A and B have different number values");
            }

            b.Message = "Struct B";

            Console.WriteLine("\nMessage field of struct A: " + a.ToString());
            Console.WriteLine("\nMessage field of struct B: " + b.ToString());
        }
    }
 */
}