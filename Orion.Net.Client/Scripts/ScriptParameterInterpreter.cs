using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Orion.Net.Client.Scripts
{
    /// <summary>
    /// Interpreter of Parameters contained in a string
    /// </summary>
    public static class ScriptParameterInterpreter
    {
        /// <summary>
        /// RegexPattern use to search parameter's name and their value in a string
        /// </summary>
        /// <example>-parameter parameterValue</example>"
        private const string RegexPattern = @"(-([a-zA-Z]+) ""([a-zA-Z0-9\\:\. \/]+)"")+";

        /// <summary>
        /// Extract parameters from a string to a parameter results list
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>List of <see cref="ScriptParameterInterpreterResult"/></returns>
        /// <remarks>The list returned will be empty if no parameter matches</remarks>
        public static List<ScriptParameterInterpreterResult> ExtractParams(this string parameters)
        {
            var result = new List<ScriptParameterInterpreterResult>();

            if (string.IsNullOrWhiteSpace(parameters) || !Regex.IsMatch(parameters, RegexPattern))
                return result;

            foreach(Match match in Regex.Matches(parameters, RegexPattern))
            {
                if(match.Groups != null && match.Groups.Count == 4)
                {
                    result.Add(new ScriptParameterInterpreterResult()
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
