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
    /// <inheritdoc/>
    /// <para>Execute a process command on the client side</para>
    /// </summary>
    public class ExecuteProcessClientScript : BaseClientScript
    {
        /// <summary>
        /// Title of the parameter
        /// </summary>
        private const string filePathParam = "filePath";
        /// <summary>
        /// Title of the arguments
        /// </summary>
        private const string argsParam = "args";
        /// <summary>
        /// Constructor with the Client connector base on <see cref="BaseClientScript"/>
        /// </summary>
        /// <param name="connector">Client Connector</param>
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

        /// <summary>
        /// <inheritdoc/>
        /// <para>Override for <see cref="ExecuteProcessClientScript"/></para>
        /// </summary>
        public override string Title => "Execute process";
        /// <summary>
        /// Private identifier to set <see cref="Identifier"/>
        /// </summary>
        private readonly Guid identifier;
        /// <summary>
        /// <inheritdoc/>
        /// Override for <see cref="ExecuteProcessClientScript"/>
        /// </summary>
        public override Guid Identifier => identifier;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        /// <exception cref="Exception">If the execute process fails, send back an error message</exception>
        public override async Task Execute(string parameters)
        {
            var paramItems = await LoadParameters(parameters);

            if (paramItems.Count == 0)
                return;

            var parameter = paramItems.FirstOrDefault(e => e.ParameterName == filePathParam);
            var arguments = paramItems.FirstOrDefault(e => e.ParameterName == argsParam);

            if (parameter == null)
            {
                await SendStringContent("Error : Parameter " + filePathParam + " is missing.");
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