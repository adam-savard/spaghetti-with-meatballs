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
        /// <param name="author"></param>
        public static void WriteAuthor(Author author)
        {
            //XmlWriterSettings settings = new XmlWriterSettings();
            //settings.Indent = true;
            //XmlWriter writer = XmlWriter.Create(Path.Combine(DocPath, "authors.xml"), settings);

            XDocument doc = XDocument.Load(Path.Combine(DocPath, "authors.xml"));
            int id = Writer.GenerateNextId(doc, "author");
            XElement newAuthor = doc.Element("authors");
            newAuthor.Add(new XElement("author",
                       new XElement("id", id),
                       new XElement("name", author.Name)));
            doc.Save(Path.Combine(DocPath, "authors.xml"));

        }

        static int GenerateNextId(XDocument file, string elementName)
        {
            var count = file.XPathSelectElements("//" + elementName).Count();

            return count;
        }
    }
}
