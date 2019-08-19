
var app = angular.module('newsApp', []);

// https://www.w3schools.com/angular/angular_scopes.asp
app.run(function ($rootScope) {
    $rootScope.numberOfNews = 0;
});

// Det går att ha flera olika controllers som gör olika saker och mycket handlar 
// om att gruppera logik så att det blir enklare att t.ex förvalta applikationen.
// I koden nedan har jag kommenterat bort seedData för att visa att den rutinen lika gärna kan ligga i myButtonController.
app.controller('httpController', function ($scope, $http) {
    //$scope.seedData = function () {
    //    console.log('Re-create clicked!');
    //    $http.post('api/news/seed', null, null)
    //        .then(function (response) {
    //            alert(response.status);
    //        });
    //};
    $scope.recreateData = function () {
        console.log('Re-create clicked!');
        $http.post('api/news/recreate') // Detta anrop har bara URL till den end-point som skall anropas. Man behöver inte ange configuration och data.
            .then(function (response) {
                alert(response.status);
            });
    };
});

app.controller('myButtonController', function ($scope, $rootScope, $http) {
    $scope.seedData = function () {
        console.log('Seed clicked!');
        $http.post('api/news/seed', null, null) // Man behöver inte ange null och null eftersom att det finns flera överlagringar. parametrarna anger configuration och data som skall postas. 
            .then(function (response) {
                alert(response.status);
            });
    };
    $scope.clickStatArea = function () {
        console.log('clickStatArea clicked!');
        $http.get('api/news/count') // Exempel på ett anrop som använder GET för att hämta data.
            .then(function (response) {
                $rootScope.numberOfNews = response.data.length;
                myLogMessage('$scope.numberOfNews', $scope.numberOfNews);
            });
    };
    $scope.clickShowAddNews = function () {
        console.log('clickShowAddNews clicked!');
    };
});

app.controller('myNewsListController', function ($scope, $rootScope, $http) {
    $http.get("api/news")
        .then(function (response) {
            $scope.content = response.data;
            $scope.statuscode = response.status;
            $scope.statustext = response.statusText;

            $rootScope.numberOfNews = response.data.length;

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
