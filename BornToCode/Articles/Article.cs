using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using BornToCode.ExceptionHandling.Exceptions;

namespace BornToCodeModels
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DatePublished { get; set; }

        protected Article() { }

        public Article(Guid id, string title, string content)
        {
            CheckForEmptyGuid(id);
            CheckForNull(new[] { title, content });
            Id = id;
            Title = title;
            Content = content;
            DatePublished = DateTime.Now;
        }

        private void CheckForEmptyGuid(Guid id)
        {
            if(id == Guid.Empty)
                throw new BadFormat();
        }

        private void CheckForNull(string[] parameters)
        {
            if (parameters.Any(value => string.IsNullOrWhiteSpace(value)))
                throw new BadFormat();
        }

        public static bool operator == (Article a, Article b)
        {
            return a.Id == b.Id && a.Title == b.Title && a.Content == b.Content;
        }

        public static bool operator != (Article a, Article b)
        {
            return a.Id != b.Id || a.Title != b.Title || a.Content != b.Content;
        }
    }
}
