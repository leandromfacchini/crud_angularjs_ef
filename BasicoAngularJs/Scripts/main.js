/// <reference path="../lib/angular.js" />
var app = angular.module('blog', ['ngRoute']);

//definindo a rota
app.config(function ($routeProvider) {

console.log('o puto passou aqui');

    $routeProvider
        .when('/', { templateUrl: 'views/home.html' })
        .when('/artigos', { templateUrl: 'views/artigos.html', controller: 'ArtigosController' })
        .when('/sobre', { templateUrl: 'views/sobre.html' })
});

app.controller('ArtigosController', function ($scope) {

    $scope.artigos = [
        "Artigo 1",
        "Artigo 2",
        "Artigo 3",
        "Artigo 4"
    ];
});