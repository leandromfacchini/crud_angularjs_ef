var app = angular
    .module("macModule", [])
    .controller("macController", function ($scope, stringService) {

        $scope.transformarTexto = function (input) {
            $scope.output = stringService.processarTexto(input);
        }
    });