
var app = angular.module('newsApp', []);
app.controller('myController', function ($scope) {
    $scope.clickSeed = function () {
        alert('clickSeed clicked!');
    };
    $scope.clickStatArea = function () {
        alert('clickStatArea clicked!');
    };
});

