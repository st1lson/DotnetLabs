using Lab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Lab1
{
    internal class Program
    {
        private static void Main()
        {
            Author firstAuthor = new()
            {
                FirstName = "John",
                Patronymic = "Christopher",
                LastName = "Depp",
                Workplace = "The Black Pearl"
            };
            Author secondAuthor = new()
            {
                FirstName = "William",
                Patronymic = "Francis",
                LastName = "Nighy",
                Workplace = "The Flying Dutchman"
            };
            Author thirdAuthor = new()
            {
                FirstName = "Jack",
                LastName = "Sparrow",
                Workplace = "The Black Pearl"
            };
            List<Author> authorsCollection = new()
            {
                firstAuthor,
                secondAuthor,
                thirdAuthor
            };

            Article firstArticle = new()
            {
                Name = "First article",
                ReleaseDate = DateTime.Now - TimeSpan.FromDays(1),
                Authors = new List<Author>() { firstAuthor, secondAuthor }
            };
            Article secondArticle = new()
            {
                Name = "Second article",
                ReleaseDate = DateTime.Now - TimeSpan.FromDays(2),
                Authors = new List<Author>() { firstAuthor, thirdAuthor }
            };
            Article thirdArticle = new()
            {
                Name = "Third article",
                ReleaseDate = DateTime.Now - TimeSpan.FromMinutes(15),
                Authors = new List<Author>() { secondAuthor, thirdAuthor }
            };
            List<Article> articlesCollection = new()
            {
                firstArticle,
                secondArticle,
                thirdArticle
            };

            Journal journal = new()
            {
                Name = "Time",
                Copies = 100000,
                Frequency = TimeSpan.FromDays(7),
                ReleaseDate = DateTime.Now,
                Articles = new List<Article>() { firstArticle, secondArticle }
            };
            Journal secondJournal = new()
            {
                Name = "No name",
                Copies = 10,
                Frequency = TimeSpan.FromDays(30),
                ReleaseDate = DateTime.Now - TimeSpan.FromDays(7)
            };
            List<Journal> journalsCollection = new()
            {
                journal,
                secondJournal
            };

            firstArticle.Journal = journal;
            secondArticle.Journal = journal;

            IEnumerable<Author> authors = firstArticle.Authors.Select(a => a);
            PrintArray(authors);

            IEnumerable<string> names = firstArticle.Authors.Select(a => a.FirstName);
            PrintArray(names);

            var anonymousType = secondArticle.Authors
                .Select(a => new { a.FirstName, a.LastName });
            PrintArray(anonymousType);

            IEnumerable<Article> articles = journal.Articles.Where(a => a.Authors.Count > 0);
            PrintArray(articles);

            IEnumerable<Article> sortedArticles = journal.Articles.OrderByDescending(a => a.Name);
            PrintArray(sortedArticles);

            IEnumerable<Author> sortedAuthors = firstArticle.Authors
                .Where(a => a.Workplace != string.Empty)
                .OrderBy(a => a.LastName)
                .ThenBy(a => a.FirstName);
            PrintArray(sortedAuthors);

            IEnumerable<Author> limitedAuthors = firstArticle.Authors
                .TakeLast(1);
            PrintArray(limitedAuthors);


            double averageCopies = journalsCollection.Average(j => j.Copies);
            Console.WriteLine(averageCopies);

            IEnumerable<Article> limitedArticles = journal.Articles
                .SkipWhile(a => a.ReleaseDate < DateTime.Now - TimeSpan.FromDays(30) || a.ReleaseDate > DateTime.Now);
            PrintArray(limitedArticles);

            IEnumerable<Author> specificAuthors = authorsCollection
                .Where(a => Regex.IsMatch(a.FirstName, @"[Jj]ohn"));
            PrintArray(specificAuthors);

            var groupedAuthors =
                from a in firstArticle.Authors
                group a by a.Workplace into g
                select new { Name = g.Key, Count = g.Count() };
            if (groupedAuthors is null)
            {
                throw new ArgumentNullException(nameof(groupedAuthors));
            }

            groupedAuthors = firstArticle.Authors.GroupBy(a => a.Workplace)
                .Select(a => new { Name = a.Key, Count = a.Count() });
            PrintArray(groupedAuthors);

            var detailedArticles =
                from j in journalsCollection
                join a in articlesCollection on j equals a.Journal
                select new { JorunalName = j.Name, ArticleName = a.Name };
            PrintArray(detailedArticles);

            IEnumerable<Author> unitedArticle = default;
            for(int i = 0; i < articlesCollection.Count - 1; i++)
            {
                unitedArticle = articlesCollection[i].Authors.Union(articlesCollection[i + 1].Authors);
            }
            PrintArray(unitedArticle);

            IEnumerable<Author> intersectedAuthors = firstArticle.Authors.Intersect(secondArticle.Authors);
            PrintArray(intersectedAuthors);

            Article author = articlesCollection.FirstOrDefault(a => Regex.IsMatch(a.Name, @"[Ss]econd"));
            if (author is not null)
            {
                Console.WriteLine(author);
            }
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
