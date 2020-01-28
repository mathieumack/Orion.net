using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Interfaces;
using Orion.Net.Core.Results;

namespace Orion.Net.Core.UnitTests.Results.StringContent
{
    /// <summary>
    /// Unit Test for <see cref="StringContentResult"/>
    /// Verify instantiation of <see cref="StringContentResult.ResultType"/> to <see cref="ClientScriptResultType.ConsoleLog"/>
    /// </summary>
    [TestClass]
    public class StringContentTestResultType
    {
        [TestMethod]
        public void StringTestResultType()
        {
            StringContentResult testContent = new StringContentResult();

            Assert.AreEqual(ClientScriptResultType.ConsoleLog, testContent.ResultType);
        }
    }
}