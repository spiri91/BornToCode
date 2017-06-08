using System;
using BornToCodeModels;

namespace BornToCodeTests
{
    public static class TestsConstants
    {
        public const string Title = "TestTitle";

        public const string Content = "TestContent";

        public const string Resume = "TestResume";

        public const string Url = "https://google.com/"; //@"http://localhost:49403/#!/";

        public static Article BuildNewArticle(string title = Title, string content = Content)
            => new Article(Guid.NewGuid(), Resume, Title, Content);
    }
}
