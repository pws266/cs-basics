namespace CSharpBasics.src
{
    using System;
    using System.Collections.Generic;

    // verifies custom comparer class
    public class CompareTestChecker
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
            Console.Title = "List of C# collections sorted by standard manner";

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
