using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Core.Results;
using System;

namespace Orion.Net.Core.UnitTests.Results.StringContent
{
    [TestClass]
    public class StringContentTestSerialize
    {
        [TestMethod]
        public void Serialize()
        {
            StringContentResult testContent = new StringContentResult();

            try
            {
                Assert.IsNotNull(testContent.GenerateDataContent());
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
