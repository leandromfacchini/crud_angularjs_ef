//criar module
var app = angular.module('produtosApp', []);

//criando o controller
app.controller('produtosCtrl', function ($scope, $http) {

    $http.get('ProdutosService.asmx/getProdutos')
        .then(function (response) {
            $scope.produtos = response.data;
        })
});