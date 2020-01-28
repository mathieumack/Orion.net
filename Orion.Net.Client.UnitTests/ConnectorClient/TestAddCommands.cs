using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;
using Orion.Net.Scripts.Common.Diagnostics;
using Orion.Net.Client.Scripts;

namespace Orion.Net.Client.UnitTests.ConnectorClient
{
    /// <summary>
    /// Unit Test for <see cref="Connector"/>
    /// Check the method <see cref="Connector.AddCommandService{T}(T)"/> with the two types of <see cref="BaseCientScript"/>
    /// <list type="number">
    /// <item>Check that the list of <see cref="BaseClientScript"/> is empty at the instantiation</item>
    /// <item>Check the list has two items after the execution of the method</item></list>
    /// </summary>
    /// <remarks> Due to a error "System.IO.FileNotFoundException" 
    /// Has to add Microsoft.Bcl.AsyncInterfaces in PackageReference</remarks>    [TestClass]
    public class TestAddCommands
    {
        [TestMethod]
        public void TestAddCommandValid()
        {
            Connector test = new Connector();

            Assert.AreEqual(0, test.commands.Count);

            test.AddCommandService(new ExecuteProcessClientScript(test));
            test.AddCommandService(new SendImageContentClientScript(test));

            Assert.AreEqual(2, test.commands.Count);
        }
    }
}
