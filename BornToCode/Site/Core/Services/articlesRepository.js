app.factory('articlesRepository', ['messageService', articlesRepository]);

function articlesRepository(messageService) {
    this._GetArticles = (take, skip) => {
        return messageService._GET("odata/articles");
    };

    return this;
}