app.factory('articlesRepository', ['messageService', articlesRepository]);

function articlesRepository(messageService) {
    let odataArticlesAddress = "odata/articles";

    this._GetArticles = () => {
        return messageService._GET(odataArticlesAddress);
    };

    this._GetSingleArticle = (id) => {
        return messageService._GET(odataArticlesAddress + "(" + id + ")");
    };

    this._GetArticlesByQuery = (query) => {
        return messageService._GET(odataArticlesAddress + query);
    };

    this._Save = (token, article) => {
        return messageService._POST(odataArticlesAddress, article, token);
    };

    return this;
}