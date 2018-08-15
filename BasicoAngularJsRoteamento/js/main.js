/// <reference path="../lib/angular.js" />

var app = angular.module('blog', ['ngRoute']);

//definir rota
app.config(function ($routeProvider) {

    $routeProvider
        .when('/', { templateUrl: '/views/home.html' })
        .when('/artigos', { templateUrl: '/views/artigos.html', controller: 'ArtigosController' })
        .when('/sobre', { templateUrl: '/views/sobre.html', controller: 'SobreController' })
        .otherwise({ redirectTo: "/" })
});

app.controller('ArtigosController', function ($scope) {

    $scope.artigos = [
        "C# - Com programação orientada a objetos",
        "Banco de dados com sql server",
        "AngularJs"
    ];

});

app.controller('SobreController', function ($scope) {

    $scope.titulo = "Sobre";
    $scope.nome = "Teste da página sobre";
    $scope.sobre = "Teste de página";
});