using System;
using System.Collections.Generic;
using System.Text;

namespace meatballs.classes
{
    public class Project
    {
        private string name;
        private int id;
        private DateTime created;
        private Author author;
        private string language; //could be broken out into a separate language class, but that's honestly overdoing it

        /// <summary>
        /// The name of the project.
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// The unique identifier for the project. Also for easier filtering.
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// The date of project creation. Defaults to now.
        /// </summary>
        public DateTime Created { get => created; set => created = value; }
        /// <summary>
        /// The primary language of the project (c#, etc).
        /// </summary>
        public string Language { get => language; set => language = value; }
        /// <summary>
        /// The author of the project.
        /// </summary>
        public Author Author { get => author; set => author = value; }

        public Project(string name, int id, DateTime created, string language, Author author)
        {
            Name = name;
            Id = id;
            Created = created;
            Language = language;
            Author = author;
        }
    }
}
