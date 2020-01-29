using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Orion.Net.Client.Configuration;
using Orion.Net.Client.Scripts;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Scripts.Common.Diagnostics
{
    /// <summary>
    /// Execute a process command on the client
    /// </summary>
    public class ExecuteProcessClientScript : BaseClientScript
    {
        private const string filePathParam = "filePath";
        private const string argsParam = "args";

        public ExecuteProcessClientScript(Connector connector)
            : base(connector)
        {
            identifier = Guid.NewGuid();
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = filePathParam
            });
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = argsParam
            });
        }

        public override string Title => "Execute process";

        private readonly Guid identifier;
        public override Guid Identifier => identifier;

        public override async Task Execute(string parameters)
        {
            var paramItems = await LoadParameters(parameters);

            if (paramItems.Count == 0)
            {
                return;
            }

            var parameter = paramItems.FirstOrDefault(e => e.ParameterName == filePathParam);
            var arguments = paramItems.FirstOrDefault(e => e.ParameterName == argsParam);

            if(parameter == null)
            {
                await SendStringContent("Error : Parameter" + filePathParam + "is missing.");
                return;
            }

            try
            {
                if (arguments == null)
                    Process.Start(parameter.ParameterValue);
                else
                    Process.Start(parameter.ParameterValue, arguments.ParameterValue);

                await SendStringContent("File opened.");
            }
            catch (Exception ex)
            {
                await SendStringContent("An error occured : " + ex.Message);
            }
        }
    }
}