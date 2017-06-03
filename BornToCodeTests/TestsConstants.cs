using System;
using BornToCodeModels;

namespace BornToCodeTests
{
    public static class TestsConstants
    {
        public const string Title = "TestTitle";

        public const string Content = "TestContent";

        public static Article BuildNewArticle(string title = Title, string content = Content)
            => new Article(Guid.NewGuid(), Title, Content);
    }
}
