using System;
using System.ComponentModel.DataAnnotations;

namespace BornToCodeModels
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime DatePublished { get; set; }

        public Article() { }

        public Article(Guid id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
            DatePublished = DateTime.Now;
        }
    }
}
