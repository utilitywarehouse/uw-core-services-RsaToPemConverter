using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace RSAToPEMTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string xml = @"C:\workspace\SSP-UW\Elec\public.xml";
            string pem = @"C:\workspace\SSP-UW\Elec\public.pem";

            bool result = RSAToPEMConverter.Converter.Convert(xml);
            FileInfo fi = new FileInfo(pem);

            Assert.IsTrue(result);
            
            Assert.IsTrue(fi.Exists);

        }
    }
}
