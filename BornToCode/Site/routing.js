/// <reference path="app.js" />
app.config(($routeProvider) => {
    $routeProvider
        .when('/', {
            templateUrl: "Site/Articles/Articles.html",
            controller: 'articlesController'
        })
        .when('/writeNew', {
            templateUrl: '',
            controller: '',
        })
        .when('/:id', {
            templateUrl: '',
            controller: '',
        })
        .when('/edit/:id', {
            templateUrl: '',
            controller: '',
        });
});