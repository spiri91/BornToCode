/// <reference path="../_defaultScripts.js" />
/// <reference path="../app.js" />

app.controller('articlesController', ['$scope', 'articlesRepository', articlesController]);

function articlesController($scope, articlesRepository) {
    articlesRepository._GetArticles().then((result) => {
        $scope.articles = result.data.value;
    });
}