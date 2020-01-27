using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;
using Orion.Net.Client.Scripts;
using Orion.Net.Core.Scripts;
using System;
using System.Threading.Tasks;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript.BaseScript
{
    [TestClass]
    public class TestClassBaseClientScript : BaseClientScript
    {
        private Guid identifier;

        public bool TestExecuteResult;

        public override string Title => "TestClass";

        public override Guid Identifier => identifier;

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
            TestExecuteResult = (paramItems.Count !=0) ? true : false;
        }
    }
}
