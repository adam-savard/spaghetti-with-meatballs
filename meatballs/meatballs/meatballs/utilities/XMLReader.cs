using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using meatballs.classes;

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
            if (!System.IO.File.Exists(Path.Combine(config_dir, "authors.xml")))
            {
                XDocument doc = new XDocument(new XElement("authors"));
                doc.Save(Path.Combine(config_dir, "authors.xml"));
            }
            if (!System.IO.File.Exists(Path.Combine(config_dir, "projects.xml"))) {
                XDocument doc = new XDocument(new XElement("projects"));
                doc.Save(Path.Combine(config_dir, "projects.xml"));
            }

            if (!System.IO.File.Exists(Path.Combine(config_dir, "files.xml"))) {
                XDocument doc = new XDocument(new XElement("files"));
                doc.Save(Path.Combine(config_dir, "files.xml"));
            }
            if (!System.IO.File.Exists(Path.Combine(config_dir, "functions.xml"))) {
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

        /// <summary>
        /// Gets an author based on name. Case insensitive. Returns a dummy author if invalid.
        /// </summary>
        /// <param name="name">The name of the author to test</param>
        /// <returns></returns>
        public static Author GetAuthorFromName(string name)
        {
            string config_dir = Path.Combine(DocPath, "xml");
            XDocument doc = XDocument.Load(Path.Combine(config_dir, "authors.xml"));

            var query = from a in doc.Elements("authors").Elements("author")
                        where a.Element("name").ToString().Equals(name) //TODO: Think about changing to .Contains()
                        select a;

            foreach(var result in query)
            {
                return new Author(result.Element("name").Value, int.Parse(result.Element("id").Value), DateTime.Parse(result.Element("created").Value), result.Element("notes").Value);
            }

            return new Author("none", -1, DateTime.Now, "none");


        }

        /// <summary>
        /// Gets an author based on ID. Returns a dummy author if invalid.
        /// </summary>
        /// <param name="id">The author ID</param>
        /// <returns></returns>
        public static Author GetAuthorFromID(int id)
        {
            string config_dir = Path.Combine(DocPath, "xml");
            XDocument doc = XDocument.Load(Path.Combine(config_dir, "authors.xml"));

            var query = from a in doc.Elements("authors").Elements("author")
                        where (int)a.Element("id") == id //TODO: Think about changing to .Contains()
                        select a;

            foreach (var result in query)
            {
                return new Author(result.Element("name").Value, int.Parse(result.Element("id").Value), DateTime.Parse(result.Element("created").Value), result.Element("notes").Value);
            }

            return new Author("none", -1, DateTime.Now, "none");
        }
    }
}
