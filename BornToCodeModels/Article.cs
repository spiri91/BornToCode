using System;
using System.ComponentModel.DataAnnotations;
using NullGuard;

[assembly: NullGuard(ValidationFlags.All)]
namespace BornToCodeModels
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DatePublished { get; private set; }

        public Article(Guid id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
            DatePublished = DateTime.Now;
        }
    }
}
