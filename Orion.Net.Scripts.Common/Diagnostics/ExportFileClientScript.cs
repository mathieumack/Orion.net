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
        public ExportFileClientScript(Connector connector)
            : base(connector)
        {
            identifier = Guid.NewGuid();
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = "filePath"
            });
            AvailableParameters.Add(new ScriptParameter()
            {
                Name = "args"
            });
        }

        public override string Title => "Export File";

        private readonly Guid identifier;
        public override Guid Identifier => identifier;

        public override async Task Execute(string parameters)
        {
            var paramItems = parameters.ExtractParams();
            var parameter = paramItems.FirstOrDefault(e => e.ParameterName == "exportFile");
            if (parameter == null)
            {
                await SendStringContent("parameter invalid. exportFile not valid.");
                await SendStringContent("parameter invalid. exportFile not valid.");
                await SendStringContent("parameter invalid. exportFile not valid.");
                await SendStringContent("parameter invalid. exportFile not valid.");
                return;
            }

            var arguments = paramItems.FirstOrDefault(e => e.ParameterName == "args");

            try
            {
                if (arguments == null)
                    await SendStringContent("No path file entered in args.");
                else
                {
                    //string testPath = @"C:\Users\cadier\Downloads\Logoeconocom.jpg";
                    await SendFileContent(arguments.ParameterValue);
                    await SendStringContent("File exported.");
                }

            }
            catch (Exception ex)
            {
                await SendStringContent("An error occured : " + ex.Message);
            }
        }
    }
}

