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
    /// <para>Send Image from the client computer to be display</para>
    /// </summary>
    public class SendImageContentClientScript : BaseClientScript
    {
        /// <summary>
        /// Parameter's Name of <see cref="SendImageContentClientScript"/>
        /// </summary>
        private const string filePathParam = "filePath";
        /// <summary>
        /// Constructor of <see cref="SendImageContentClientScript"/> with the Client connector
        /// </summary>
        /// <param name="connector">Client connector</param>
        public SendImageContentClientScript(Connector connector)
            : base(connector)
        {
            identifier = Guid.NewGuid();
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = filePathParam
            });
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override string Title => "Send Image";
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
        /// <exception cref="Exception">Fail to execute command, send back an error message</exception>
        public override async Task Execute(string parameters)
        {
            var paramItems = await LoadParameters(parameters);

            if (paramItems.Count == 0)
            {
                return;
            }

            try
            {
                var parameter = paramItems.FirstOrDefault(e => e.ParameterName == filePathParam);
                await SendImageContent(parameter.ParameterValue);
            }
            catch (Exception ex)
            {
                await SendStringContent("An error occured : " + ex.Message);
            }
        }
    }
}
