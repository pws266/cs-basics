using System;
using System.Collections.Generic;

namespace CSharpBasics
{
    // performs reverse comparision of collection elements
    class CompareTest : IComparer<TestClass>
    {
        // implemented interface method
        public int Compare(TestClass x, TestClass y)
        {
            return Math.Sign(y.Number - x.Number);
        }
    }

    // verifies custom comparer class
    class VerifyCompareTest
    {
        // displays specified list content
        static void ShowListContent(List<TestClass> list, string message)
        {
            Console.WriteLine(message);
            foreach (TestClass x in list)
                // last argument invokes "x.ToString" method
                Console.WriteLine("Rent price: {0, 4}$ Model: {1}", x.Number, x);
        }

        public static void Main()
        {
            // creating comparer and list instances
            CompareTest comparer = new CompareTest();
            List<TestClass> list = new List<TestClass>();

            // filling the list
            list.Add(TestClass.Factory(10, "Lada Kalina"));
            list.Add(TestClass.Factory(150, "Kia Sportage"));
            list.Add(TestClass.Factory(25, "Kia Rio"));
            list.Add(TestClass.Factory(70, "Renault Laguna"));
            list.Add(TestClass.Factory(200, "Nissan Navaro"));
            list.Add(TestClass.Factory(3, "Fiat Panda"));
            list.Add(TestClass.Factory(45, "Opel Meriva"));

            ShowListContent(list, "> Source list content:");

            // sorting list content according the rule developed in "comparer"
            list.Sort(comparer);

            ShowListContent(list, "\n> Sorted list content:");
        }
    }
}
