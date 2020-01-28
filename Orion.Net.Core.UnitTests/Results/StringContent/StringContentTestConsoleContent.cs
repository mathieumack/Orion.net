using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Results;

namespace Orion.Net.Core.UnitTests.Results.StringContent
{
    /// <summary>
    /// Unit Test for <see cref="StringContentResult"/>
    /// <list type="number">
    /// <item>Verify <see cref="StringContentResult.ConsoleContent"/> is not instantiated</item>
    /// <item>Verify <see cref="StringContentResult.ConsoleContent"/> set and get</item>
    /// </list>
    /// </summary>
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