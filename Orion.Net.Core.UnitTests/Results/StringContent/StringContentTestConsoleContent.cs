using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Results;

namespace Orion.Net.Core.UnitTests.Results.StringContent
{
    [TestClass]
    public class StringContentTestConsoleContent
    {
        [TestMethod]
        public void StringTestConsoleContent()
        {
            StringContentResult testContent = new StringContentResult();

            Assert.IsNull(testContent.ConsoleContent);

            testContent.ConsoleContent = "toto";

            Assert.AreEqual("toto", testContent.ConsoleContent);
        }
    }
}