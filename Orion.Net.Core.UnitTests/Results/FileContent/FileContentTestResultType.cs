using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Interfaces;
using Orion.Net.Core.Results;

namespace Orion.Net.Core.UnitTests.Results.FileContent
{
    [TestClass]
    public class FileContentTestResultType
    {
        [TestMethod]
        public void FileTestResultType()
        {
            FileContentResult testContent = new FileContentResult();

            Assert.AreEqual(ClientScriptResultType.File, testContent.ResultType);
        }
    }
}