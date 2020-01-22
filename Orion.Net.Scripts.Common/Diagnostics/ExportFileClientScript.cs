using System;
using System.Linq;
using System.Threading.Tasks;
using Orion.Net.Client.Configuration;
using Orion.Net.Client.Scripts;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Scripts.Common.Diagnostics
{
    /// <summary>
    /// Export file from the client's computer
    /// </summary>
    public class ExportFileClientScript : BaseClientScript
    {
        /// <summary>
        /// Argument's Name of <see cref="ExportFileClientScript"/>
        /// </summary>
        private const string argsParam = "args";

        public ExportFileClientScript(Connector connector)
            : base(connector)
        {
            identifier = Guid.NewGuid();
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = "exportFile"
            });
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = argsParam
            });
        }

        /// <summary>
        /// Title of the script ExportFileClientScript
        /// </summary>
        public override string Title => "Export File";

        private readonly Guid identifier;

        /// <summary>
        /// Identifier of the script ExportFileClientScript
        /// </summary>
        public override Guid Identifier => identifier;

        /// <summary>
        /// Execute the script ExportFileClientScript on the client side
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
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

