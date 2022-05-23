using System;
using System.Collections.Generic;

namespace Lab2.Models
{
    [Serializable]
    public class Journal
    {
        public string Name { get; set; }

        public int Copies { get; set; }

        public TimeSpan Frequency { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<Article> Articles { get; set; }
    }
}
