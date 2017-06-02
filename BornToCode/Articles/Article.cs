using System;
using System.ComponentModel.DataAnnotations;

namespace BornToCodeModels
{
    public class Article
    {
        [Key]
        public Guid Id { get; private set; }

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
