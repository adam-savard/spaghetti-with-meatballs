using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using meatballs.classes;
using meatballs.utilities;

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
            Match match = Regex.Match(text.Trim(), functionFinderRegex, RegexOptions.IgnoreCase); //this is essentially the same as .contains, so I might get rid of this.

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

        /// <summary>
        /// Returns a list of possible functions called by a function. Not meant to be exhaustive; manual oversight is still recommended.
        /// </summary>
        /// <param name="functionName">The name of the function</param>
        /// <param name="reader">Your provided stream reader.</param>
        /// <returns></returns>
        public static List<string> AnalyzeFunctions(string functionName, StreamReader reader, bool includeMethods)
        {
            List<string> functions = new List<string>();
            bool foundFunction = false;
            int levelsDeep = 0;

            string line;
            while((line = reader.ReadLine()) != null)
            {
                if(line.Contains("function") && line.Contains("(") && line.Contains(functionName))
                {
                    foundFunction = true;
                }

                if (foundFunction)
                {
                    if (line.Contains("{"))
                    {
                        levelsDeep++;
                    }

                    //The thought process is that if a line is not a function line, then we need to split the string on the ( char to get the functions
                    //not all items will actually be functions; most will be ifs. So, check against a list of those and filter them out.
                    if(!line.Contains("function") && line.Contains("(") && levelsDeep > 0)
                    {
                        string[] possibleFunctions = line.Split('(');

                        //only gets the first function, not the later.
                        foreach(string s in possibleFunctions)
                        {
                            
                                string possibleName = s;
                                possibleName = possibleName.Replace("(", "");

                                //after making a shorter string, split on spaces.
                                string[] extractedName = possibleName.Split(' ');

                                //the last one should be the closest to the ( char
                                possibleName = extractedName[extractedName.Length - 1];
                                possibleName = possibleName.Trim();
                                if(includeMethods == false)
                            {
                                if (possibleName.Contains(".")) continue;
                            }
                                //final sanity check
                                if (line.Contains(possibleName + "(") && !possibleName.Equals(string.Empty) && !StringContainsReservedWords(possibleName))
                                {
                                    functions.Add(possibleName);
                                }
                            

                            
                        }
                    }

                    if (line.Contains("}"))
                    {
                        levelsDeep--;
                        //don't loop more than you need to.
                        if (levelsDeep == 0) break;
                    }
                }
            }

            return functions;
        }

        /// <summary>
        /// Returns true if string contains reserved words
        /// </summary>
        /// <param name="s">The string to check</param>
        /// <returns></returns>
        public static bool StringContainsReservedWords(string s)
        {
            if (s == string.Empty) return false;

            
            char lastChar = s[s.Length - 1];
            //not a letter character? get out of here.
            if ((int)lastChar < 65 || (int)lastChar > 122) return true;

            if ((int)lastChar >= 91 && (int)lastChar <= 96) return true;

            string[] reservedWords = { "if", "else", "switch", "for" }; //subject to expand as necssary

            foreach(string r in reservedWords)
            {
                if (s.Equals(r)) return true;
            }

            return false;
        }
    }
}
