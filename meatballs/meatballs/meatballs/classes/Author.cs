using System;
using System.Collections.Generic;
using System.Text;

namespace meatballs.classes
{
    /// <summary>
    /// The author of a given file, project, function, etc. Contains all necessary information on project members.
    /// </summary>
    public class Author
    {
        
        private string name;
        private int id;
        private DateTime created;
        private string notes;

        /// <summary>
        /// The name of the contributor
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// The ID of the contributor. Used as a unique identifier. 
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// The date that the contributor was created. Defaults to now on new creation.
        /// </summary>
        public DateTime Created { get => created; set => created = value; }
        /// <summary>
        /// Any notes on the creator (for things like termination date, etc)
        /// </summary>
        public string Notes { get => notes; set => notes = value; }
    }
}
