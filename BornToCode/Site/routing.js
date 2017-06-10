/// <reference path="app.js" />
app.config(($routeProvider) => {
    $routeProvider
        .when('/', {
            templateUrl: "Site/Articles/Articles.html",
            controller: 'articlesController'
        })
        .when('/article/:id?', {
            templateUrl: 'Site/NewOrEdit/NewOrEdit.html',
            controller: 'newOrEditController'
        })
        .when('/:title', {
            templateUrl: 'Site/Article/Article.html',
            controller: 'articleController'
        })
        .otherwise({
            templateUrl: "Site/Articles/Articles.html",
            controller: 'articlesController'
        });
});