
var app = angular.module('newsApp', []);

app.controller('httpController', function ($scope, $http) {
    $scope.seedData = function () {
        console.log('Re-create clicked!');
        $http.post('api/news/seed', null, null)
            .then(function (response) {
                alert(response.status);
            });
    };
    $scope.recreateData = function () {
        console.log('Seed clicked!');
        $http.post('api/news/recreate', null, null)
            .then(function (response) {
                alert(response.status);
            });
    };
});

app.controller('myButtonController', function ($scope) {
    //$scope.clickSeed = function () {
    //    console.log('clickSeed clicked!');
    //    //$http({
    //    //    method : 'POST',
    //    //    url : "api/news/seed"
    //    //})
    //    //    .then(function (response) {
    //    //        alert(response.statusText);
    //    //    });
    //};
    $scope.clickStatArea = function () {
        console.log('clickStatArea clicked!');
    };
    //$scope.clickRecreate = function () {
    //    console.log('clickRecreate clicked!');
    //};
    $scope.clickShowAddNews = function () {
        console.log('clickShowAddNews clicked!');
    };
});

app.controller('myNewsListController', function ($scope, $http) {
    $http.get("api/news")
        .then(function (response) {
            $scope.content = response.data;
            $scope.statuscode = response.status;
            $scope.statustext = response.statusText;
            $scope.showUpdateNewsForm = function (id) {
                console.log('showUpdateNewsForm: ' + id);
            };
            $scope.deleteNews = function (id) {
                myLogMessage('deleteNews', id);
            };
        });
});

function myLogMessage(message, id) {
    console.log(message + ': ' + id);
}
