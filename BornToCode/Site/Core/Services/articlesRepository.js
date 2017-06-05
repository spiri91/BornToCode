app.factory('articlesRepository', ['messageService', articlesRepository]);

function articlesRepository(messageService) {
    this._GetArticles = (query) => {
        return messageService._GET("odata/articles" + query);
    };

    return this;
}