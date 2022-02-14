using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Models
{
    internal class Article
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();

        public override string ToString()
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine($"Article name - {Name}");
            stringBuilder.AppendLine($"Release date - {ReleaseDate}");
            stringBuilder.AppendLine("Authors:");
            stringBuilder.AppendLine(string.Join(", ", Authors));

            return stringBuilder.ToString();
        }
    }
}
