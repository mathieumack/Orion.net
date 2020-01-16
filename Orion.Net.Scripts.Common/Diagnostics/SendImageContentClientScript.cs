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
    public class SendImageContentClientScript : BaseClientScript
    {
        public SendImageContentClientScript(Connector connector)
            : base(connector)
        {
            identifier = Guid.NewGuid();
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = "sendImage"
            });
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = "args"
            });
        }

        public override string Title => "Send Image";

        private readonly Guid identifier;
        public override Guid Identifier => identifier;

        public override async Task Execute(string parameters)
        {
            var paramItems = parameters.ExtractParams();
            var parameter = paramItems.FirstOrDefault(e => e.ParameterName == "sendImage");
            if (parameter == null || parameter.ParameterName != "sendImage")
            {
                await SendStringContent("parameter invalid. Image not found.");
                return;
            }

            try
            {
                await SendImageContent(parameter.ParameterValue);
            }
            catch (Exception ex)
            {
                await SendStringContent("An error occured : " + ex.Message);
            }
        }
    }
}
