namespace CSharpBasics.test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using CSharpBasics.src;

    [TestClass]
    public class SingletonTest
    {
        // Tests list:
        // [+] One instance;
        // [+] Two instances.

        [TestMethod]
        public void OneInstanceCreation()
        {
            Singleton<Configuration> st = Singleton<Configuration>.Instance;
            Assert.IsTrue(st != null);
        }

        [TestMethod]
        public void TwoInstancesCheck()
        {
            Singleton<Configuration> st0 = Singleton<Configuration>.Instance;
            Singleton<Configuration> st1 = Singleton<Configuration>.Instance;

            Assert.IsTrue(st0 == st1);
        }
    }
}
