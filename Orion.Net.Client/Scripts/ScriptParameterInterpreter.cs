using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Orion.Net.Client.Scripts
{
    public static class CareCenterScriptParameterInterpreter
    {
        private const string RegexPattern = @"(-([a-zA-Z]+) ""([a-zA-Z0-9\\:\. \/]+)"")+";

        /// <summary>
        /// Extract parameters from a string to a parameter results list
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static List<CareCenterScriptParameterInterpreterResult> ExtractParams(this string parameters)
        {
            var result = new List<CareCenterScriptParameterInterpreterResult>();

            if (string.IsNullOrWhiteSpace(parameters) || !Regex.IsMatch(parameters, RegexPattern))
                return result;

            foreach(Match match in Regex.Matches(parameters, RegexPattern))
            {
                if(match.Groups != null && match.Groups.Count == 4)
                {
                    result.Add(new CareCenterScriptParameterInterpreterResult()
                    {
                        ParameterName = match.Groups[2].Value,
                        ParameterValue = match.Groups[3].Value
                    });
                }
                else
                {
                    // Error to be managed :

                }
            }

            return result;
        }
    }
}
