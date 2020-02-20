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
    /// <remarks>Command in the navigator = -filePath "path/to/file" </remarks>
    public class ExportFileClientScript : BaseClientScript
    {
        /// <summary>
        /// Argument's Name of <see cref="ExportFileClientScript"/>
        /// </summary>
        private const string param = "filePath";

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
                Name = param
            });
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = "args"
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

            var parameter = paramItems.FirstOrDefault(e => e.ParameterName == param);

            try
            {
                if (parameter == null)
                    await SendStringContent("No path file entered in " + parameter);
                else
                {
                    await SendFileContent(parameter.ParameterValue);
                }

            }
            catch (Exception ex)
            {
                await SendStringContent("An error occured : " + ex.Message);
            }
        }
    }
}
