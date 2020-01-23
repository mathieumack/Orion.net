using System;
using System.Linq;
using System.Threading.Tasks;
using Orion.Net.Client.Configuration;
using Orion.Net.Client.Scripts;
using Orion.Net.Core.Scripts;

namespace Orion.Net.Scripts.Common.Diagnostics
{
    /// <summary>
    /// Send Image from the client computer to be display
    /// </summary>
    public class SendImageContentClientScript : BaseClientScript
    {
        /// <summary>
        /// Parameter's Name of <see cref="SendImageContentClientScript"/>
        /// </summary>
        private const string filePathParam = "filePath";

        public SendImageContentClientScript(Connector connector)
            : base(connector)
        {
            identifier = Guid.NewGuid();
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = filePathParam
            });
        }

        public override string Title => "Send Image";

        private readonly Guid identifier;
        public override Guid Identifier => identifier;

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
