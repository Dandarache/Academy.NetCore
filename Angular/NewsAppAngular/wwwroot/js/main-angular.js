
var app = angular.module('newsApp', []);

// https://www.w3schools.com/angular/angular_scopes.asp

app.run(function ($rootScope, $http) {
    $rootScope.news = [];
    $rootScope.numberOfNews = $rootScope.news.length;
    $rootScope.categories = [];
    $rootScope.numberOfCategories = $rootScope.categories.length;
    $rootScope.addArea = false;
    $rootScope.updateArea = false;


    // --------------------------------------
    // Uppdatera applikationens data
    // --------------------------------------

    $rootScope.updateData = function () {

        console.log('updateData invoked!');

        $http.get("api/categories")
            .then(function (response) {

                // Sätter scope-variabeln till arrayen av kategorier.
                $rootScope.categories = response.data;
                console.log('$rootScope.categories' + $rootScope.categories);

                // Uppdaterar rootScope med korrekt värde för antal kategorier som finns i databasen.
                $rootScope.numberOfCategories = response.data.length;

            });

        $http.get("api/news")
            .then(function (response) {

                // Sätter scope-variabeln content till arrayen av nyheter.
                //$scope.content = response.data;
                $rootScope.news = response.data;
                console.log('$rootScope.news' + $rootScope.news);

                // Vi behöver inte skriva ut eller använda information nedan i den nuvarande implementationen.
                //$scope.statuscode = response.status;
                //$scope.statustext = response.statusText;

                // Uppdaterar rootScope med korrekt värde för antal nyheter som finns i listan just nu.
                $rootScope.numberOfNews = response.data.length;

            });
    };
    
});

// Det går att ha flera olika controllers som gör olika saker och mycket handlar 
// om att gruppera logik så att det blir enklare att t.ex förvalta applikationen.
app.controller('myAppController', function ($scope, $rootScope, $http) {

    // --------------------------------------
    // Uppdatera data och nyhetslistningen.
    // --------------------------------------

    $scope.updateData();
    $scope.content = $rootScope.news;

    // --------------------------------------
    // Återskapa databasen.
    // --------------------------------------

    $scope.recreateData = function () {
        console.log('Re-create clicked!');
        $http.post('api/news/recreate') // Detta anrop har bara URL till den end-point som skall anropas. Man behöver inte ange configuration och data.
            .then(function (response) {
                console.log(response.status);
            });
    };

    // --------------------------------------
    // Lägg till dummy-data genom att anropa "Seed".
    // --------------------------------------

    // Hantera klick på Seed-knappen.
    $scope.seedData = function () {
        console.log('Seed clicked!');
        $http.post('api/news/seed', null, null) // Man behöver inte ange null och null eftersom att det finns flera överlagringar. parametrarna anger configuration och data som skall postas. 
            .then(function (response) {
                console.log(response.status);
            });

        $scope.updateData();
    };

    // --------------------------------------
    // Visa statistik
    // --------------------------------------

    // Hantera klick på Statistics-knappen.
    $scope.clickStatArea = function () {
        console.log('clickStatArea clicked!');
        $http.get('api/news/count') // Exempel på ett anrop som använder GET för att hämta data.
            .then(function (response) {
                $rootScope.numberOfNews = response.data;
                myLogMessage('$rootScope.numberOfNews', $rootScope.numberOfNews);
            });
    };

    // --------------------------------------
    // Lägg till nyhet
    // --------------------------------------

    // Visa formuläret för lägg till nyhet.
    $scope.clickShowAddNews = function () {
        console.log('clickShowAddNews clicked!');

        // Sätt rot-variabeln "addArea" till true för att på så sätt visa formuläret.
        // Det är kopplingen som defineras med attributet "ng-show='addArea'" som gör detta möjligt.
        $rootScope.addArea = true;
    };

    $scope.clickCancelAddNews = function () {
        console.log('clickCancelAddNews clicked!');

        // "Nollställ" fälten i formuläret.
        $scope.addAreaHeader = '';
        $scope.addAreaIntro = '';
        $scope.addAreaBody = '';

        // Göm lägg till nyhet formuläret.
        $rootScope.addArea = false;
    };

    // Hantera klick på knappen "Add" som visas i formuläret för lägg till nyhet.
    $scope.clickAddNews = function () {
        console.log('clickAddNews clicked!');

        // Skapa ett objekt med det data som tillhör den nya nyheten.
        var data = {
            header: $scope.addAreaHeader,
            intro: $scope.addAreaIntro,
            body: $scope.addAreaBody,
            category: {
                id: $scope.addAreaCategory
            }
        };
        console.log(data); // logga objektet
        console.log(JSON.stringify(data)); // logga objektet som en sträng

        // För att end-point i WebAPI skall kunna tolka datat som skickas i anropet
        // behöver man tala om att det är JSON genom att använda MIME-typen "application/json".
        var config = {
            headers: {
                'Content-Type': 'application/xml'
            }
        };

        // Spara den nya nyheten.
        $http.post(
            'api/news', // URL till den end-point som skall anropas.
            JSON.stringify(data), // Objektet för data behöver "plattas" till så att det blir en sträng och inte ett objekt.
            JSON.stringify(config)) // Samma sak gäller för objektet för konfigurationen, dvs det behöver plattas till.
            .then(

                // Denna metod körs om allt gick bra.
                function (response) {
                    alert('Rock n Roll: ' + response.statusText);
                }

                // Kommatecknet nedan skiljer gott och ont, dvs om requesten lyckades eller misslyckades.
                ,

                // Denna metod körs om något strulade.
                function (response) {
                    alert('Aj, aj, aj: ' + response.statusText);
                }
            );

        // "Nollställ" fälten i formuläret.
        $scope.addAreaHeader = '';
        $scope.addAreaIntro = '';
        $scope.addAreaBody = '';

        // Göm "Lägg till nyhet"-dialogen.
        $rootScope.addArea = false;

        $scope.updateData();

    };

    // --------------------------------------
    // Uppdatera nyhet
    // --------------------------------------

    // Hantera klick på knappen för att UPPDATERA nyhet som visas i tabellen.
    $scope.clickUpdateNewsForm = function (obj) {
        console.log('clickUpdateNewsForm: ' + obj.header);

        // "Nollställ" fälten i formuläret.
        $scope.updateAreaId = obj.id;
        $scope.updateAreaHeader = obj.header;
        $scope.updateAreaIntro = obj.intro;
        $scope.updateAreaBody = obj.body;
        $scope.updateAreaCategory = obj.category;

        // Visa "Updatera nyhet"-dialogen.
        $rootScope.updateArea = true;
    };

    // Hantera klick på knappen för att avbryta UPPDATERA nyhet som visas i tabellen.
    $scope.clickCancelUpdateNews = function () {
        console.log('clickCancelUpdateNews');

        // Göm "Updatera nyhet"-dialogen.
        $rootScope.updateArea = false;
    };

    // Hantera klick på "Update"-knappen i uppdatera nyhet formuläret.
    $scope.clickUpdateNews = function () {
        console.log('clickUpdateNews');

        // Skapa ett objekt med det data som tillhör den nya nyheten.
        var data = {
            id: $scope.updateAreaId,
            header: $scope.updateAreaHeader,
            intro: $scope.updateAreaIntro,
            body: $scope.updateAreaBody,
            category: {
                id: $scope.updateAreaCategory
            }
        };
        console.log(data); // logga objektet
        console.log(JSON.stringify(data)); // logga objektet som en sträng

        // För att end-point i WebAPI skall kunna tolka datat som skickas i anropet
        // behöver man tala om att det är JSON genom att använda MIME-typen "application/json".
        var config = {
            headers: {
                'Content-Type': 'application/xml'
            }
        };

        // Spara den nya nyheten genom att göra en PUT-request mot end-point.
        $http.put(
            'api/news', // URL till den end-point som skall anropas.
            JSON.stringify(data), // Objektet för data behöver "plattas" till så att det blir en sträng och inte ett objekt.
            JSON.stringify(config)) // Samma sak gäller för objektet för konfigurationen, dvs det behöver plattas till.
            .then(

                // Denna metod körs om allt gick bra.
                function (response) {
                    alert('Rock n Roll: ' + response.statusText);
                }

                // Kommatecknet nedan skiljer gott och ont, dvs om requesten lyckades eller misslyckades.
                ,

                // Denna metod körs om något strulade.
                function (response) {
                    alert('Aj, aj, aj: ' + response.statusText);
                }
            );

        // "Nollställ" fälten i formuläret.
        $scope.updateAreaId = '';
        $scope.updateAreaHeader = '';
        $scope.updateAreaIntro = '';
        $scope.updateAreaBody = '';

        // Göm "Updatera nyhet"-dialogen.
        $rootScope.updateArea = false;
    };

    // --------------------------------------
    // Radera nyhet
    // --------------------------------------

    // Hantera klick på knappen för att RADERA nyhet som visas i tabellen.
    $scope.clickDeleteNews = function (id) {
        myLogMessage('clickDeleteNews', id);

        // Detta anrop anropar en end-point med DELETE (HttpDelete) i MVC som tar en parameter (id).
        $http.delete(`api/News/${id}`)

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


// --------------------------------------
// Vanliga JavaScript-metoder går naturligtvis också att använda.
// --------------------------------------

function myLogMessage(message, id) {
    console.log(message + ': ' + id);
}
