using System;
using System.Collections.Generic;
using System.Text;
using meatballs.classes;

namespace meatballs.call_stack
{
    /// <summary>
    /// Creats a nice and ugly call stack class given set parameters. Be warned, this might make your head hurt.
    /// </summary>
    public class CallStack
    {
        private List<File> files = new List<File>();
        private List<Function> functions = new List<Function>();
        private Function callingFunction;


        /// <summary>
        /// List of files
        /// </summary>
        public List<File> Files { get => files; set => files = value; }
        /// <summary>
        /// List of functions
        /// </summary>
        public List<Function> Functions { get => functions; set => functions = value; }

        public CallStack(Function function)
        {
            GenerateCallstackFromFunction(function);
        }

        //TODO: Figure this out when I'm not tired.
        public void GenerateCallstackFromFunction(Function function)
        {

        }
    }
}
