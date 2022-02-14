using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Lab1.Models;

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
                Authors = new List<Author>() { firstAuthor }
            };

            Journal journal = new()
            {
                Name = "Time",
                Copies = 100000,
                Frequency = TimeSpan.FromDays(7),
                ReleaseDate = DateTime.Now,
                Articles = new List<Article>() { firstArticle, secondArticle }
            };

            IEnumerable<Author> authors = firstArticle.Authors.Select(a => a);
            PrintArray(authors);

            IEnumerable<string> names = firstArticle.Authors.Select(a => a.FirstName);
            PrintArray(names);

            var anonymousType = secondArticle.Authors.Select(a => new { a.FirstName, a.LastName });
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
