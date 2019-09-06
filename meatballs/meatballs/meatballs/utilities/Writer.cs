using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using meatballs.classes;

namespace meatballs.utilities
{
    /// <summary>
    /// Writes output to XML files given the pre-determined path.
    /// </summary>
    public static class Writer
    {
        static readonly string docPath = Path.Combine(XMLReader.DocPath, "xml");

        public static string DocPath => docPath;


        /// <summary>
        /// Writes a new entry in the Authors.xml file
        /// </summary>
        /// <param name="author">An author object to parse</param>
        public static void WriteAuthor(Author author)
        {
            

            XDocument doc = XDocument.Load(Path.Combine(DocPath, "authors.xml"));
            int id = Writer.GenerateNextId(doc, "author");
            XElement newAuthor = doc.Element("authors");
            newAuthor.Add(new XElement("author",
                       new XElement("id", id),
                       new XElement("name", author.Name),
                       new XElement("notes", author.Notes),
                       new XElement("created", DateTime.Now.ToShortDateString())));
            doc.Save(Path.Combine(DocPath, "authors.xml"));

        }

        /// <summary>
        /// Wries a new entry to the projects.xml file.
        /// </summary>
        /// <param name="project">The project object to parse</param>
        public static void WriteProject(Project project)
        {
            

            XDocument doc = XDocument.Load(Path.Combine(DocPath, "projects.xml"));
            int id = Writer.GenerateNextId(doc, "project");
            XElement newAuthor = doc.Element("projects");
            newAuthor.Add(new XElement("project",
                       new XElement("id", id),
                       new XElement("name", project.Name),
                       new XElement("language", project.Language),
                       new XElement("author", project.Author.Id),
                       new XElement("created", DateTime.Now.ToShortDateString())));
            doc.Save(Path.Combine(DocPath, "project.xml"));

        }

        /// <summary>
        /// Writes a file to files.xml
        /// </summary>
        /// <param name="file">The file object to parse</param>
        public static void WriteFile(classes.File file)
        {


            XDocument doc = XDocument.Load(Path.Combine(DocPath, "files.xml"));
            int id = Writer.GenerateNextId(doc, "file");
            XElement newAuthor = doc.Element("files");
            newAuthor.Add(new XElement("file",
                       new XElement("id", id),
                       new XElement("name", file.Name),
                       new XElement("extension", file.Extension),
                       new XElement("created", DateTime.Now.ToShortDateString()),
                       new XElement("project", file.Project.Id),
                       new XElement("author", file.Author.Id),
                       new XElement("description",file.Description),
                       new XElement("notes", file.Notes)));
            doc.Save(Path.Combine(DocPath, "files.xml"));

        }

        /// <summary>
        /// Recursive method to get to root functions and add them.
        /// </summary>
        /// <param name="function">The function object to parse</param>
        public static int WriteFunction(Function function)
        {
            //functions are a little different since they can call each other. First, we have to check if the function.Calls is populated
            XElement calls = new XElement("calls");

            if(function.Calls.Count > 0)
            {
                //next, we add all the function calls to the xelement
                foreach(Function f in function.Calls)
                {
                    //this gets to the "bottom" calling function (with no calls), and then makes its way back to the top.
                    //recursion is scary, so this could break everything if circular logic exists.
                    int calls_id = WriteFunction(f);
                    calls.Add(new XElement("function_id", calls_id));
                }
            }
            else
            {
                XDocument doc = XDocument.Load(Path.Combine(DocPath, "functions.xml"));
                int id = Writer.GenerateNextId(doc, "function");
                XElement newAuthor = doc.Element("functions");
                newAuthor.Add(new XElement("function",
                           new XElement("id", id),
                           new XElement("name", function.Name),
                           new XElement("file", function.File.Id),
                           new XElement("created", DateTime.Now.ToShortDateString()),
                           new XElement("author", function.Author.Id),
                           new XElement("description", function.Description),
                           calls,
                           new XElement("notes", function.Notes)));
                doc.Save(Path.Combine(DocPath, "files.xml"));
            }

            

            return function.Id;
        }

        static int GenerateNextId(XDocument file, string elementName)
        {
            var count = file.XPathSelectElements("//" + elementName).Count();

            return count;
        }
    }
}
