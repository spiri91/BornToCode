/// <reference path="../_defaultScripts.js" />
/// <reference path="../Core/Services/localStorageService.js" />
/// <reference path="../Core/Services/articlesRepository.js" />
app.controller('articleController', ['$scope', '$routeParams', 'articlesRepository', articleController]);

function articleController($scope, $routeParams, articlesRepository) {
    function init() {
        let selectedArticle = localStorageService.getSelectedArticle();
        if (!selectedArticle)
            articlesRepository._GetArticlesByQuery("?$filter=title eq '" + $routeParams.title + "'")
                .then((response) => {
                    $scope.article = response.data.value[0];
                });

        $scope.article = selectedArticle;
    }

    init();
}