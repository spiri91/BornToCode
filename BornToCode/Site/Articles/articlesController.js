/// <reference path="../_defaultScripts.js" />
/// <reference path="../app.js" />
/// <reference path="../Core/Services/localStorageService.js" />

app.controller('articlesController', ['$scope', '$location', 'articlesRepository', articlesController]);

function articlesController($scope, $location, articlesRepository) {
    articlesRepository._GetArticles().then((result) => {
        $scope.articles = result.data.value;
    });

    $scope.onSelectedArticle = (article) => {
        localStorageService.rememberArticle(article);
        let articleAddress = '/' + article.title;
        $location.path(articleAddress);
    };
}