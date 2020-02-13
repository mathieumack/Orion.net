using System;
using System.Linq;
using System.Threading.Tasks;
using Orion.Net.Client.Configuration;
using Orion.Net.Client.Scripts;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Scripts.Common.Diagnostics
{
    /// <summary>
    /// <inheritdoc/>
    /// <para>Export file from the client's computer</para>
    /// </summary>
    public class ExportFileClientScript : BaseClientScript
    {
        /// <summary>
        /// Argument's Name of <see cref="ExportFileClientScript"/>
        /// </summary>
        private const string argsParam = "args";

        /// <summary>
        /// Constructor of <see cref="ExportFileClientScript"/> with the Client Connector
        /// </summary>
        /// <param name="connector"></param>
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
        /// <inheritdoc/>
        /// </summary>
        public override string Title => "Export File";
        /// <summary>
        /// Private identifier to set <see cref="Identifier"/>
        /// </summary>
        private readonly Guid identifier;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override Guid Identifier => identifier;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="parameters"></param>
        /// <exception cref="Exception">Fail to execute the command, send back an error message</exception>
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
