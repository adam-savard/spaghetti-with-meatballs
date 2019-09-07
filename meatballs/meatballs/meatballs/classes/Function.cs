using System;
using System.Collections.Generic;
using System.Text;

namespace meatballs.classes
{
    public class Function
    {
        private string name;
        private string description;
        private string notes;
        private Author author;
        private File file;
        private List<Function> calls;
        private int id;

        /// <summary>
        /// The name of the function, the method signature.
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// A description of what the function does/is for.
        /// </summary>
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// Any notes on the function (api calls, etc)
        /// </summary>
        public string Notes { get => notes; set => notes = value; }
        /// <summary>
        /// The author of the function
        /// </summary>
        public Author Author { get => author; set => author = value; }
        /// <summary>
        /// The file the function belongs to.
        /// </summary>
        public File File { get => file; set => file = value; }

        //The .this is intentional. Not sure how else to get the point across.
        /// <summary>
        /// List of functions .this calls.
        /// </summary>
        public List<Function> Calls { get => calls; set => calls = value; }
        public int Id { get => id; set => id = value; }

        public Function(string name, string description, string notes, Author author, File file, int id)
        {
            Name = name;
            Description = description;
            Notes = notes;
            Author = author;
            File = file;
            Id = id;
            Calls = new List<Function>();
        }
    }
}
