using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;
using Orion.Net.Scripts.Common.Diagnostics;

namespace Orion.Net.Client.UnitTests.ConnectorClient
{
    [TestClass]
    public class TestAddCommands
    {
        /// <summary>
        /// Add a command service, as <see cref="ExecuteProcessClientScript"/>, to commands in <see cref="Connector"/>
        /// </summary>
        /// <remarks> Due to a error "System.IO.FileNotFoundException" 
        /// Has to ass Microsoft.Bcl.AsyncInterfaces in PackageReference</remarks>
        [TestMethod]
        public void TestAddCommandValid()
        {
            Connector test = new Connector();

            Assert.IsNotNull(test.commands);

            Assert.AreEqual(0, test.commands.Count);

            test.AddCommandService(new ExecuteProcessClientScript(test));

            Assert.AreEqual(1, test.commands.Count);
        }
    }
}
