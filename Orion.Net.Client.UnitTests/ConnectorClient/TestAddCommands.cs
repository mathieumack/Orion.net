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
        /// <list type="bullet">
        /// <item><term>First Assert Instantiation</term>
        /// <description>Verify that the list is not null and the count is at 0</description></item>
        /// <item><term>Second Assert Add a Command Service</term>
        /// <description>Verify that the list of Commands has 1 command added to it</description></item>
        /// </list>
        /// </summary>
        /// <remarks> Due to a error "System.IO.FileNotFoundException" 
        /// Has to add Microsoft.Bcl.AsyncInterfaces in PackageReference</remarks>
        [TestMethod]
        public void TestAddCommandValid()
        {
            Connector test = new Connector();

            Assert.AreEqual(0, test.commands.Count);

            test.AddCommandService(new ExecuteProcessClientScript(test));

            Assert.AreEqual(1, test.commands.Count);
        }
    }
}
