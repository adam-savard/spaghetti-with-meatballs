using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Linq;
using meatballs.classes;

namespace meatballs.utilities
{
    /// <summary>
    /// Reads from predefined XML files.
    /// </summary>
    public static class XMLReader
    {
        //There is a bare minimum of 4 XML files that need to be parsed
        //1. authors.xml
        //2. files.xml
        //3. functions.xml
        //4. projects.xml
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

            return new Author(name, -1, DateTime.Now, "none");


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

        /// <summary>
        /// Gets a file from a filename.
        /// </summary>
        /// <param name="name">The file name</param>
        /// <returns></returns>
        public static classes.File GetFileFromName(string name)
        {
            string config_dir = Path.Combine(DocPath, "xml");
            XDocument doc = XDocument.Load(Path.Combine(config_dir, "files.xml"));

            var query = from f in doc.Elements("files").Elements("file")
                        where f.Element("name").ToString().Equals(name) //TODO: Think about changing to .Contains()
                        select f;

            foreach (var result in query)
            {
                return new classes.File(int.Parse(result.Element("id").Value), result.Element("name").Value, result.Element("description").Value, result.Element("notes").Value, result.Element("extension").Value, GetProjectFromID(int.Parse(result.Element("project").Value)), GetAuthorFromID(int.Parse(result.Element("author").Value)));
            }

            return new classes.File(-1, name, "none", "none", ".exe", GetProjectFromID(-1), GetAuthorFromID(-1));
        }

        
        /// <summary>
        /// Gets a file from a given ID.
        /// </summary>
        /// <param name="id">The ID of the file.</param>
        /// <returns></returns>
        public static classes.File GetFileFromID(int id)
        {
            string config_dir = Path.Combine(DocPath, "xml");
            XDocument doc = XDocument.Load(Path.Combine(config_dir, "files.xml"));

            var query = from f in doc.Elements("files").Elements("file")
                        where (int)f.Element("id") == id 
                        select f;

            foreach (var result in query)
            {
                return new classes.File(int.Parse(result.Element("id").Value), result.Element("name").Value, result.Element("description").Value, result.Element("notes").Value, result.Element("extension").Value, GetProjectFromID(int.Parse(result.Element("project").Value)), GetAuthorFromID(int.Parse(result.Element("author").Value)));
            }

            return new classes.File(-1, "none", "none", "none", ".exe", GetProjectFromID(-1), GetAuthorFromID(-1));
        }

        
        /// <summary>
        /// Gets a project from a given ID.
        /// </summary>
        /// <param name="id">The ID of the project.</param>
        /// <returns></returns>
        public static Project GetProjectFromID(int id)
        {
            string config_dir = Path.Combine(DocPath, "xml");
            XDocument doc = XDocument.Load(Path.Combine(config_dir, "projects.xml"));

            var query = from p in doc.Elements("projects").Elements("project")
                        where (int)p.Element("id") == id
                        select p;

            foreach (var result in query)
            {
                return new Project(result.Element("name").Value, int.Parse(result.Element("id").Value), DateTime.Parse(result.Element("created").Value), result.Element("language").Value, GetAuthorFromID(int.Parse(result.Element("author").Value)));
            }
            return new Project("none", -1, DateTime.Now, "none", GetAuthorFromID(-1));
        }

        /// <summary>
        /// Gets a project from a name.
        /// </summary>
        /// <param name="name">The name of the project.</param>
        /// <returns></returns>
        public static Project GetProjectFromName(string name)
        {
            string config_dir = Path.Combine(DocPath, "xml");
            XDocument doc = XDocument.Load(Path.Combine(config_dir, "projects.xml"));

            var query = from f in doc.Elements("projects").Elements("project")
                        where f.Element("name").ToString().Equals(name) //TODO: Think about changing to .Contains()
                        select f;

            foreach (var result in query)
            {
                return new Project(result.Element("name").Value, int.Parse(result.Element("id").Value), DateTime.Parse(result.Element("created").Value), result.Element("language").Value, GetAuthorFromID(int.Parse(result.Element("author").Value)));
            }

            return new Project(name, -1, DateTime.Now, "none", GetAuthorFromID(-1));
        }

        /// <summary>
        /// Gets a function and all the functions it calls from a given ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Function GetFunctionByID(int id)
        {
            string config_dir = Path.Combine(DocPath, "xml");
            XDocument doc = XDocument.Load(Path.Combine(config_dir, "functions.xml"));

            var query = from f in doc.Elements("functions").Elements("function")
                        where (int)f.Element("id") == id
                        select f;

            foreach (var result in query)
            {
                List<Function> calls = new List<Function>();

                foreach (var fid in result.Element("calls").DescendantNodes()) {
                    if(fid.NodeType != System.Xml.XmlNodeType.Element)
                    {
                        calls.Add(GetFunctionByID(int.Parse(fid.ToString())));
                    }
                }

                Function f = new Function(result.Element("name").Value, result.Element("description").Value, result.Element("notes").Value, GetAuthorFromID(int.Parse(result.Element("author").Value)), GetFileFromID(int.Parse(result.Element("file").Value)), int.Parse(result.Element("id").Value));
                f.Calls = calls;
                return f;
            }

            return new Function("none", "none", "none", GetAuthorFromID(-1), GetFileFromID(-1), -1);
            
        }

        /// <summary>
        /// Gets a function based on its name.
        /// </summary>
        /// <param name="name">The name of the function.</param>
        /// <returns></returns>
        public static Function GetFunctionByName(string name)
        {
            string config_dir = Path.Combine(DocPath, "xml");
            XDocument doc = XDocument.Load(Path.Combine(config_dir, "functions.xml"));

            var query = from f in doc.Elements("functions").Elements("function")
                        where f.Element("name").ToString().Equals(name)
                        select f;

            foreach (var result in query)
            {
                List<Function> calls = new List<Function>();

                foreach (var fid in result.Element("calls").DescendantNodes())
                {
                    if (fid.NodeType != System.Xml.XmlNodeType.Element)
                    {
                        calls.Add(GetFunctionByID(int.Parse(fid.ToString())));
                    }
                }

                Function f = new Function(result.Element("name").Value, result.Element("description").Value, result.Element("notes").Value, GetAuthorFromID(int.Parse(result.Element("author").Value)), GetFileFromID(int.Parse(result.Element("file").Value)), int.Parse(result.Element("id").Value));
                f.Calls = calls;
                return f;
            }

            return new Function(name, "none", "none", GetAuthorFromID(-1), GetFileFromID(-1), -1);

        }
    }
}
