/// <reference path="../_defaultScripts.js" />
/// <reference path="../app.js" />
/// <reference path="../Core/Services/localStorageService.js" />

app.controller('articlesController', ['$scope', '$location', 'articlesRepository', articlesController]);

function articlesController($scope, $location, articlesRepository) {
    var query = '?$select=id,resume,title,datePublished';
    articlesRepository._GetArticlesByQuery(query).then((result) => {
        $scope.articles = result.data.value;
        loader.hide();
    });

    $scope.onSelectedArticle = (article) => {
        let articleAddress = '/' + encodeURIComponent(article.title);
        loader.show();
        $location.path(articleAddress);
    };
}