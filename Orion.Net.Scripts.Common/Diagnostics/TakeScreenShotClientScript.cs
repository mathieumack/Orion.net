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
    public class TakeScreenShotClientScript : BaseClientScript
    {
        public TakeScreenShotClientScript(Connector connector)
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

        public override string Title => "Take screenshot";

        private readonly Guid identifier;
        public override Guid Identifier => identifier;

        public override async Task Execute(string parameters)
        {
            var paramItems = parameters.ExtractParams();
            var parameter = paramItems.FirstOrDefault(e => e.ParameterName == "screenshot");
            if (parameter == null)
            {
                await SendStringContent("parameter invalid. Screenshot not taken.");
                await SendStringContent("parameter invalid. Screenshot not taken.");
                await SendStringContent("parameter invalid. Screenshot not taken.");
                await SendStringContent("parameter invalid. Screenshot not taken.");
                return;
            }

            try
            {
                string testPath = @"C:\Users\cadier\Downloads\Logoeconocom.jpg";
                await SendImageContent(testPath);
                await SendStringContent("ScreenShot taken.");
            }
            catch (Exception ex)
            {
                await SendStringContent("An error occured : " + ex.Message);
            }
        }
    }
}
