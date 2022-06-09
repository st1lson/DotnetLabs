using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Lab2
{
    internal class Program
    {
        private static void Main()
        {
            XElement data = XElement.Load("xmlFile1.xml");

            IEnumerable<XElement> authors = data.Descendants("Article").ElementAt(0).Descendants("Author").Select(a => a);
            PrintArray(authors);

            IEnumerable<string> names = data.Descendants("Article").ElementAt(0).Descendants("Author").Select(a => a.Element("FirstName")?.Value);
            PrintArray(names);

            var anonymousType = data.Descendants("Article").ElementAt(1).Descendants("Author")
                .Select(a => new { FirstName = a.Element("FirstName")?.Value, LastName = a.Element("LastName")?.Value });
            PrintArray(anonymousType);

            IEnumerable<XElement> articles = data.Descendants("Journal").ElementAt(0).Descendants("Article").Where(a => a.Descendants("Author").Any());
            PrintArray(articles);

            IEnumerable<XElement> sortedArticles = data.Descendants("Journal").ElementAt(0).Descendants("Article").OrderByDescending(a => a.Element("Name")?.Value);
            PrintArray(sortedArticles);

            IEnumerable<XElement> sortedAuthors = data.Descendants("Article").ElementAt(0).Descendants("Author")
                .Where(a => a.Element("Workplace")?.Value != string.Empty)
                .OrderBy(a => a.Element("LastName")?.Value)
                .ThenBy(a => a.Element("FirstName")?.Value);
            PrintArray(sortedAuthors);

            IEnumerable<XElement> limitedAuthors = data.Descendants("Article").ElementAt(0).Descendants("Author")
                .TakeLast(1);
            PrintArray(limitedAuthors);


            double averageCopies = data.Descendants("Journal").Average(j => (long)Convert.ToDouble(j.Element("Copies")?.Value));
            Console.WriteLine($"Average copies: {averageCopies}\n");

            IEnumerable<XElement> limitedArticles = data.Descendants("Journal").ElementAt(0).Descendants("Article")
                .SkipWhile(a => Convert.ToDateTime(a.Element("ReleaseDate")?.Value) < DateTime.Now - TimeSpan.FromDays(30) || Convert.ToDateTime(a.Element("ReleaseDate")?.Value) > DateTime.Now);
            PrintArray(limitedArticles);

            IEnumerable<XElement> specificAuthors = data.Descendants("Author")
                .Where(a => Regex.IsMatch(a.Element("FirstName")?.Value!, @"[Jj]ohn"));
            PrintArray(specificAuthors);

            var groupedAuthors =
                from a in data.Descendants("Article").ElementAt(0).Descendants("Author")
                group a by a.Element("Workplace")?.Value into g
                select new { Name = g.Key, Count = g.Count() };
            if (groupedAuthors is null)
            {
                throw new ArgumentNullException(nameof(groupedAuthors));
            }

            groupedAuthors = data.Descendants("Article").ElementAt(0).Descendants("Author").GroupBy(a => a.Element("Workplace")?.Value)
                .Select(a => new { Name = a.Key, Count = a.Count() });
            PrintArray(groupedAuthors);

            IEnumerable<XElement> unitedArticle = default;
            IEnumerable<XElement> articlesData = data.Descendants("Article");
            for (int i = 0; i < articlesData.Count() - 1; i++)
            {
                unitedArticle = articlesData.ElementAt(i).Descendants("Author").Union(articlesData.ElementAt(i).Descendants("Author"));
            }
            PrintArray(unitedArticle);

            string author = data.Descendants("Article").FirstOrDefault(a => Regex.IsMatch(a.Element("Name")?.Value!, @"[Ss]econd"))?.Value;
            Console.WriteLine(author);
        }

        private static void PrintArray<T>(IEnumerable<T> array)
        {
            foreach (T value in array)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();
        }
    }
}
