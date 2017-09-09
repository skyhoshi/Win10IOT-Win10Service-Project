using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Service_Logic_Tests
{
    [TestClass]
    public class Encrypto_Tests
    {
        [TestMethod]
        public void EncryptDebugOutput()
        {
            System.Diagnostics.Debug.WriteLine(SkyhoshiEncryption.Crypto.EncryptStringAES("InsertPasswordHere","InsertSaltHere"));
        }
    }
}
