using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Lab2.Models
{
    [Serializable]
    public class Article
    {
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }

        [XmlIgnore]
        public Journal Journal { get; set; }

        [XmlArray]
        public List<Author> Authors { get; set; } = new();

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
