using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service_Logic_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            System.Diagnostics.Debug.WriteLine(SkyhoshiEncryption.Crypto.EncryptStringAES("InsertPasswordHere","InsertSaltHere"));
        }
    }
}
