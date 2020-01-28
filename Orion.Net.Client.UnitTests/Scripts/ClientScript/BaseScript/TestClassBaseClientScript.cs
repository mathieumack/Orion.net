using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;
using Orion.Net.Client.Scripts;
using Orion.Net.Core.Scripts;
using System;
using System.Threading.Tasks;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.BaseScript
{
    /// <summary>
    /// TestClass herited from <see cref="BaseClientScript"/> to implement Unit Test
    /// </summary>
    [TestClass]
    public class TestClassBaseClientScript : BaseClientScript
    {
        private Guid identifier;

        /// <summary>
        /// To verify <see cref="BaseClientScript.Execute(string)"/>
        /// </summary>
        public bool TestExecuteResult;

        public override string Title => "TestClass";

        public override Guid Identifier => identifier;

        /// <summary>
        /// Instantiation the attributes
        /// </summary>
        /// <param name="connector"></param>
        public TestClassBaseClientScript(Connector connector) : base(connector)
        {
            TestExecuteResult = false;
            identifier = Guid.NewGuid();
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = "test"
            });
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = "args"
            });
        }

        /// <summary>
        /// Return true if param correspond, else false
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public override async Task Execute(string parameters)
        {
            var paramItems = await LoadParameters(parameters);
            TestExecuteResult = (paramItems.Count != 0) ? true : false;
        }

        /// <summary>
        /// Test for protected method <see cref="BaseClientScript.SendStringContent(string)"/>
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public bool TestSendStringContent(string test)
        {
            try
            {
                SendStringContent(test);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Test for protected method <see cref="BaseClientScript.SendImageContent(string)"/>
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public bool TestSendImageContent(string test)
        {
            try
            {
                SendImageContent(test);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Test for protected method <see cref="BaseClientScript.SendFileContent(string)"/>
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        public bool TestSendFileContent(string test)
        {
            //TODO
            return false;
        }
    }
}
