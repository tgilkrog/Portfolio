using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BusinessLayer;
using ModelLayer;

namespace Test
{
    [TestClass]
    public class StorageTest
    {
        StorageController sCtr = new StorageController();

        [TestMethod]
        public void TestMethod1()
        {
            Storage storage = sCtr.GetDrinkStorage(1, 1);

            Assert.AreEqual(storage.Amount, 25);
        }
    }
}
