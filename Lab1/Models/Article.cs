using System;
using System.Collections.Generic;

namespace Lab1.Models
{
    internal class Article
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public Journal Journal { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}
