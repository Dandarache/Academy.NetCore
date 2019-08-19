
var app = angular.module('newsApp', []);

// https://www.w3schools.com/angular/angular_scopes.asp
app.run(function ($rootScope) {
    $rootScope.news = [];
    $rootScope.numberOfNews = $rootScope.news.length;
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
                $rootScope.numberOfNews = response.data;
                myLogMessage('$rootScope.numberOfNews', $rootScope.numberOfNews);
            });
    };
    $scope.clickShowAddNews = function () {
        console.log('clickShowAddNews clicked!');
    };
});

app.controller('myNewsListController', function ($scope, $rootScope, $http) {
    $http.get("api/news")
        .then(function (response) {

            // Sätter scope-variabeln content till arrayen av nyheter.
            $scope.content = response.data;
            $rootScope.news = response.data;

            // Vi behöver inte skriva ut eller använda information nedan i den nuvarande implementationen.
            //$scope.statuscode = response.status;
            //$scope.statustext = response.statusText;

            // Uppdaterar rootScope med korrekt värde för antal nyheter som finns i listan just nu.
            $rootScope.numberOfNews = response.data.length;

            // Hantera klick på knappen för att UPPDATERA nyhet som visas i tabellen.
            $scope.showUpdateNewsForm = function (id) {
                console.log('showUpdateNewsForm: ' + id);
            };

            // Hantera klick på knappen för att RADERA nyhet som visas i tabellen.
            $scope.deleteNews = function (id) {
                myLogMessage('deleteNews', id);

                // Detta anrop anropar en end-point med DELETE (HttpDelete) i MVC som tar en parameter (id).
                $http.delete(`api/News/${id}1234`)

                    // När HTTP-anrop gjort skall följande hända
                    .then(

                        // Om allt gick bra (success) ...
                        function (response) {
                            alert(response.status);
                        }

                        ,

                        // Om någonting strulade (error) ...
                        function myError(response) {
                            if (response.status === 404) {
                                console.log(`News with id = ${id} not found`);
                            } else {
                                console.log("Unexpected error", response);
                            }
                        }
                    );

                    //--------------------
                    // Gamla koden som inte körde AngularJS
                    //--------------------

                    //let response = fetch("api/News/" + id, {
                    //    method: "DELETE",
                    //    headers: {
                    //        "Content-Type": "application/json"
                    //    }
                    //});

                    //if (response.status === 204) {

                    //    updateNewsTable();

                    //} else if (response.status === 404) {

                    //    console.log(`News with id = ${id} not found`);

                    //} else {

                    //    console.log("Unexpected error", response);

                    //}

                    //--------------------
            };
        });
});

function myLogMessage(message, id) {
    console.log(message + ': ' + id);
}
