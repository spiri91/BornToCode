/// <reference path="../_defaultScripts.js" />
/// <reference path="../Core/guid.js" />
/// <reference path="../app.js" />
/// <reference path="../Core/Services/articlesRepository.js" />
app.controller('newOrEditController', ['$scope','$routeParams', 'articlesRepository', newOrEditController]);

function newOrEditController($scope, $routeParams, articlesRepository) {
    var isPut = false;

    function init() {
        if (!$routeParams.id)
            return;

        isPut = true;
        articlesRepository._GetSingleArticle($routeParams.id).then((result) => {
            $scope.article = result.data;
        });
    }


    function success() {
        alert('saved');
    }

    function faulted(error) {
        alert('Error, check console!');
        console.log(error);
    }


    $scope.save = () => {
        if (isPut) {
            articlesRepository._Put($scope.token, $scope.article).then(success, faulted);
            return;
        }

        $scope.article.id = Guid.create().value;
        $scope.article.datePublished = new Date();
        articlesRepository._Save($scope.token, $scope.article).then(success, faulted);
    };

    init();
}