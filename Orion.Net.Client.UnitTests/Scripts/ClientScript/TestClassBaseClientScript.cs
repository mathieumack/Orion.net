using Microsoft.VisualStudio.TestTools.UnitTesting;
using Orion.Net.Client.Configuration;
using Orion.Net.Client.Scripts;
using Orion.Net.Core.Scripts;
using System;
using System.Threading.Tasks;

namespace Orion.Net.Client.UnitTests.Scripts.ClientScript
{
    [TestClass]
    public class TestClassBaseClientScript : BaseClientScript
    {
        public TestClassBaseClientScript(Connector connector) : base(connector)
        {
            identifier = Guid.NewGuid();
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = "test"
            });
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = "test"
            });
        }

        public override string Title => "TestClass";

        private Guid identifier;

        public override Guid Identifier => identifier;

        public override async Task Execute(string parameters)
        {
            var paramItems = await LoadParameters(parameters);
            return;
        }
    }
}
