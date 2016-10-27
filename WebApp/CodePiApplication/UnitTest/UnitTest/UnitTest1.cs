using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
                public void TestMethod1()
        {
            throw new NotImplementedException();
            throw new NotImplementedException();
        }
    }
}
