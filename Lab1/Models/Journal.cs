using System;
using System.Collections.Generic;

namespace Lab1.Models
{
    internal class Journal
    {
        public string Name { get; set; }

        public int Copies { get; set; }

        public TimeSpan Frequency { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}
