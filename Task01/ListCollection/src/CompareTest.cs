namespace CSharpBasics.src
{
    using System;
    using System.Collections.Generic;

    // performs reverse comparision of collection elements
    public class CompareTest : IComparer<TestClass>
    {
        // implemented interface method
        public int Compare(TestClass x, TestClass y)
        {
            return Math.Sign(y.Number - x.Number);
        }
    }
}
