﻿
var app = angular.module('myModule', []);

app.controller('myController', function ($scope, $http) {

    console.log("start controller");
    getIngredients();


    function getIngredients() {
        $http({
            method: 'Post',
            url: '/Home/GetIngredients'
        }).success(function (data, status, headers, config) {
            $scope.ingredients = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });
    }

    $scope.IngredientSelected = function () {
        var ingredientId = $scope.ingredient;
        alert("You selected " + $scope.ingredients[$scope.ingredient-1].Name);
    }
});