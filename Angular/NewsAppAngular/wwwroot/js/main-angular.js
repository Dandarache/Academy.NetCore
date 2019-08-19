
var app = angular.module('newsApp', []);

app.controller('myButtonController', function ($scope) {
    $scope.clickSeed = function () {
        alert('clickSeed clicked!');
    };
    $scope.clickStatArea = function () {
        alert('clickStatArea clicked!');
    };
});

app.controller('myNewsListController', function ($scope, $http) {
    $http.get("api/news")
        .then(function (response) {
            $scope.content = response.data;
            $scope.statuscode = response.status;
            $scope.statustext = response.statusText;
        });
});


