using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Microsoft.AspNetCore.SignalR;
using Orion.Net.Client.Configuration;
using Orion.Net.Scripts.Common.Diagnostics;
using System;

namespace Orion.Net.Client.UnitTests.ConnectorClient
{
    [TestClass]
    public class TestAddCommands
    {
        /// <summary>
        /// Add a command service, as <see cref="ExecuteProcessClientScript"/>, to commands in <see cref="Connector"/>
        /// </summary>
        /// <remarks> Not working, error :
        /// "System.IO.FileNotFoundException: Could not load file or assembly 
        /// 'Microsoft.Bcl.AsyncInterfaces, Version=1.0.0.0, Culture=neutral, PublicKeyToken=cc7b13ffcd2ddd51'. 
        /// Le fichier spécifié est introuvable."
        /// yet the file exists where it should be... (path in <see cref="IAsyncDisposable"/>)</remarks>
        [TestMethod]
        public void TestAddCommandValid()
        {
            //Mock<Connector> mockConnector = new Mock<Connector>();
            //Connector test = mockConnector.Object;

            Connector test = new Connector();

            Assert.IsNotNull(test.commands);

            Assert.AreEqual(0, test.commands.Count);

            test.AddCommandService(new ExecuteProcessClientScript(test));

            Assert.AreEqual(1, test.commands.Count);
        }

        [TestMethod]
        public void TestAddCommandNull()
        {
            Connector test = new Connector();

            ExecuteProcessClientScript testScript = null;

            try
            {
                test.AddCommandService(testScript);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }
        }
    }
}
