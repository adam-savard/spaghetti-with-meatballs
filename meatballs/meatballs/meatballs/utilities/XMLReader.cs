using System;
using System.Collections.Generic;
using System.Text;

namespace meatballs.utilities
{
    public static class XMLReader
    {
        //There is a bare minimum of 3 XML files that need to be parsed
        //1. authors.xml
        //2. files.xml
        //3. functions.xml
        //
        //These files need to exist on disk. If they don't, they should be created.


        static string path = AppDomain.CurrentDomain.BaseDirectory; //gets the path of the directory

        public static string Path { get => path; }
    }
}
