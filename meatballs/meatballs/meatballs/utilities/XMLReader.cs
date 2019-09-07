using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

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


        static string docPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "meatballs");//gets the path of the directory

        /// <summary>
        /// The main document path where everything is stored.
        /// </summary>
        public static string DocPath { get => docPath; set => docPath = value; }

        /// <summary>
        /// Creates all the necessary blank config files if they don't exist yet.
        /// </summary>
        public static void CreateWorkingDirectory()
        {
            if (!Directory.Exists(DocPath)) Directory.CreateDirectory(DocPath);

            string config_dir = Path.Combine(DocPath, "xml");

            //All of the checks lie here
            if (!Directory.Exists(config_dir)) Directory.CreateDirectory(config_dir);
            if (!File.Exists(Path.Combine(config_dir, "authors.xml")))
            {
                XDocument doc = new XDocument(new XElement("authors"));
                doc.Save(Path.Combine(config_dir, "authors.xml"));
            }
            if (!File.Exists(Path.Combine(config_dir, "projects.xml"))) {
                XDocument doc = new XDocument(new XElement("projects"));
                doc.Save(Path.Combine(config_dir, "projects.xml"));
            }

            if (!File.Exists(Path.Combine(config_dir, "files.xml"))) {
                XDocument doc = new XDocument(new XElement("files"));
                doc.Save(Path.Combine(config_dir, "files.xml"));
            }
            if (!File.Exists(Path.Combine(config_dir, "functions.xml"))) {
                XDocument doc = new XDocument(new XElement("functions"));
                doc.Save(Path.Combine(config_dir, "functions.xml"));
            }
        }

        /// <summary>
        /// Checks to see if there is a blank XML file, either a blank Project or Author file.
        /// </summary>
        /// <returns>True if there is a blank file.</returns>
        public static bool BlankXMLCheck()
        {
            string config_dir = Path.Combine(DocPath, "xml");
            XDocument doc = XDocument.Load(Path.Combine(config_dir, "authors.xml"));
            
            if (doc.Root.Elements().Count() < 1)
            {
                return true;
            }

            doc = XDocument.Load(Path.Combine(config_dir, "projects.xml"));

            if (doc.Root.Elements().Count() < 1)
            {
                return true;
            }

            return false;
        }
    }
}
