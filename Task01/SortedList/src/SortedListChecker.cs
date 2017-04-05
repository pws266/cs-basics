namespace CSharpBasics.src
{
    using System;

    // sorted list verification
    public class SortedListChecker
    {
        public static void Main()
        {
            Console.Title = "Custom list with sorting at the stage of adding elements";

            // creating sorted list instance
            SortedList list = new SortedList();

            // filling list instance and sorting data
            list.Add(TestStruct.Factory(10, "Lada Kalina"));
            list.Add(TestStruct.Factory(150, "Kia Sportage"));
            list.Add(TestStruct.Factory(25, "Kia Rio"));
            list.Add(TestStruct.Factory(70, "Renault Laguna"));
            list.Add(TestStruct.Factory(200, "Nissan Navaro"));
            list.Add(TestStruct.Factory(3, "Fiat Panda"));
            list.Add(TestStruct.Factory(45, "Opel Meriva"));

            // displaying sorted list content
            foreach (var item in list)
                // last argument invokes "item.ToString" method
                Console.WriteLine("Rent price: {0, 4}$ Model: {1}", item.Number, item);

            Console.WriteLine("\nList size: {0}", list.Size);
        }
    }
}
