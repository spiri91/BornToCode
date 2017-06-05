/// <reference path="app.js" />
app.config(($routeProvider) => {
    $routeProvider
        .when('/', {
            templateUrl: "Site/Articles/Articles.html",
            controller: 'articlesController'
        })
        .when('/writeNew', {
            templateUrl: '',
            controller: ''
        })
        .when('/:title', {
            templateUrl: 'Site/Article/Article.html',
            controller: 'articleController'
        })
        .when('/edit/:id', {
            templateUrl: '',
            controller: ''
        });
});