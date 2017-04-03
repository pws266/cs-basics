using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpBasics.Test
{
    [TestClass]
    public class SingletonTest
    {
        // Tests list:
        // [+] One instance;
        // [+] Two instances.

        [TestMethod]
        public void OneInstanceCreation()
        {
            CSharpBasics.Singleton<int> st = CSharpBasics.Singleton<int>.Instance;
            Assert.IsTrue(st != null);
        }

        [TestMethod]
        public void TwoInstancesCheck()
        {
            CSharpBasics.Singleton<int> st0 = CSharpBasics.Singleton<int>.Instance;
            CSharpBasics.Singleton<int> st1 = CSharpBasics.Singleton<int>.Instance;

            Assert.IsTrue(st0 == st1);
        }
    }
}
