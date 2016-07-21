
var app = angular.module('myModule', []);

app.controller('ingredientController', function ($scope, $http) {

    console.log("start ingredient controller");
    getIngredients();


    function getIngredients() {
        $http({
            method: 'Get',
            url: '/api/Ingredient'
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

app.controller('recipeController', function ($scope, $http) {

    console.log("start recipe controller");
    getRecipes();


    function getRecipes() {
        console.log("get recipe controller");

        $http({
            method: 'Get',
            url: '/api/BeerRecipe'
        }).success(function (data, status, headers, config) {
            $scope.recipes = data;
        }).error(function (data, status, headers, config) {
            $scope.message = 'Unexpected Error';
        });
    }

    $scope.IngredientSelected = function () {
        var ingredientId = $scope.ingredient;
        alert("You selected " + $scope.ingredients[$scope.ingredient - 1].Name);
    }
});