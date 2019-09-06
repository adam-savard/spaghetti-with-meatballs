using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace meatballs.utilities
{
    public static class FunctionReader
    {
        /// <summary>
        /// Pre-made regex to look for function( or var = function
        /// </summary>
        static string functionFinderRegex = @"(?:function)(?:.+)(?:\()";

        /// <summary>
        /// Checks to see if a line contains any functions. If so, we want to grab it and parse it.
        /// </summary>
        /// <param name="text">The line of text to be scanned.</param>
        /// <returns></returns>
        public static bool LineContainsFunction(string text)
        {
            Match match = Regex.Match(text.Trim(), functionFinderRegex, RegexOptions.IgnoreCase);

            return match.Success;
        }

        public static string GetFunctionName(string text)
        {
            string functionName = text;
            string[] retrievedName;


            if ((functionName.Contains("var") || functionName.Contains("let")) && functionName.Contains("="))
            {
                functionName = functionName.Replace("var", "");
                functionName = functionName.Replace("let", "");
                retrievedName = functionName.Split('=');
                
            }
            else
            {
                functionName = functionName.Replace("function", "");

                retrievedName = functionName.Split('(');

            }

            retrievedName[0] = retrievedName[0].Trim();

            return retrievedName[0];
        }
    }
}
