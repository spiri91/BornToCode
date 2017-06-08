/// <reference path="../_defaultScripts.js" />
/// <reference path="../Core/guid.js" />
/// <reference path="../app.js" />
/// <reference path="../Core/Services/articlesRepository.js" />
/// <reference path="F:\BornToCode\BornToCode\Scripts/moment/moment.js" />
app.controller('newOrEditController', ['$scope','$routeParams', 'articlesRepository', newOrEditController]);

function newOrEditController($scope, $routeParams, articlesRepository) {
    function init() {
        if (!$routeParams.id)
            return;

        articlesRepository._GetSingleArticle($routeParams.id).then((result) => {
            $scope.article = result.data;
        });
    }

    $scope.save = () => {
        $scope.article.id = Guid.create().value;
        $scope.article.datePublished = new Date();
        articlesRepository._Save($scope.token, $scope.article).then(() => {
            alert("Saved!");
        }, (err) => {
            alert('Error, check console!');
            console.log(err);
        });
    };

    init();
}