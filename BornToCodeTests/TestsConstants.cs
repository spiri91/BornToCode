using System;
using BornToCodeModels;

namespace BornToCodeTests
{
    public static class TestsConstants
    {
        public const string Title = "TestTitle";

        public const string Content = "TestContent";

        public const string Resume = "TestResume";

        public static Article BuildNewArticle(string title = Title, string content = Content)
            => new Article(Guid.NewGuid(), Resume, Title, Content);
    }
}
