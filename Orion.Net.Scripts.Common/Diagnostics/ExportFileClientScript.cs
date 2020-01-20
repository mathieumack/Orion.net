using System;
using System.Linq;
using System.Threading.Tasks;
using Orion.Net.Client.Configuration;
using Orion.Net.Client.Scripts;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Scripts.Common.Diagnostics
{
    /// <summary>
    /// Take a screenshot on the client computer
    /// </summary>
    public class ExportFileClientScript : BaseClientScript
    {
        private const string exportFileParam = "exportFile";
        private const string argsParam = "args";

        public ExportFileClientScript(Connector connector)
            : base(connector)
        {
            identifier = Guid.NewGuid();
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = exportFileParam
            });
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = argsParam
            });
        }

        public override string Title => "Export File";

        private readonly Guid identifier;
        public override Guid Identifier => identifier;

        public override async Task Execute(string parameters)
        {
            var paramItems = await LoadParameters(parameters);

            if (paramItems.Count == 0)
            {
                return;
            }

            var arguments = paramItems.FirstOrDefault(e => e.ParameterName == argsParam);

            try
            {
                if (arguments == null)
                    await SendStringContent("No path file entered in " + argsParam);
                else
                {
                    await SendFileContent(arguments.ParameterValue);
                }

            }
            catch (Exception ex)
            {
                await SendStringContent("An error occured : " + ex.Message);
            }
        }
    }
}

