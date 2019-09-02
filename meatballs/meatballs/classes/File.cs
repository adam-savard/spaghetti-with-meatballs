using System;
using System.Collections.Generic;
using System.Text;

namespace meatballs.classes
{
    public class File
    {
        private int id;
        private string name;
        private string extension;
        private string description;
        private string notes;
        private Project project;
        private Author author;
        private Function[] functions;

        /// <summary>
        /// The unique identifier for the file.
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// The name of the file. Extension should NOT be contained here.
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// A description of what the file contains and is for.
        /// </summary>
        public string Description { get => description; set => description = value; }
        /// <summary>
        /// Any relevant notes on the file.
        /// </summary>
        public string Notes { get => notes; set => notes = value; }
        /// <summary>
        /// The file extension (.html, .js, etc.).
        /// </summary>
        public string Extension { get => extension; set => extension = value; }
        /// <summary>
        /// The project the file belongs to.
        /// </summary>
        internal Project Project { get => project; set => project = value; }
        /// <summary>
        /// The original author of the file.
        /// </summary>
        internal Author Author { get => author; set => author = value; }
        /// <summary>
        /// A list of functions that are in the file.
        /// </summary>
        internal Function[] Functions { get => functions; set => functions = value; }
    }
}
