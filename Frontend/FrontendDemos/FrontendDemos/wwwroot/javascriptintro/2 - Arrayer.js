﻿arr1();


function arr1() {

    /*
        I---------I---------I---------I
        0         1         2         3
    
        Skapa en array "cities" med städerna Stockholm, Göteborg och New York
        Skriv ut det första, andra och tredje elementet i arrayen
        Vad händer om du försöker komma åt det fjärde elementet (som inte finns)?
    */

    let cities = ["Stockholm", "Göteborg", "Borlänge", "New York"];

    console.log(cities[0]);
    console.log(cities[1]);
    console.log(cities[2]);
    console.log(cities[3]);
    console.log(cities[4]);

    // Extra: skriv ut det andra elementet ("Göteborg") två gånger
    console.log(cities[1] + cities[1]);

    let gbg = cities[1];
    console.log(gbg + gbg);

    // Extra: Skriv ut de två första elementen vid sidan av varandra ("StockholmGöteborg")
    console.log(cities[0] + cities[1]);
}

function arr2() {

    /*
        Skapa en array "cities" med städerna Stockholm, Göteborg och New York
	    Lägg till en till stad "Krakow" mha "push"
	    Skriv ut det fjärde elementet i "cities" ("Krakow")
    */



    // Extra: använd push för att lägga till två till städer. Skriv ut den sista staden i listan.
}


function arr3() {
    /*
	    Skapa en array "cities" med städerna Stockholm, Göteborg och New York
	    Lägg till en till stad "Krakow" mha "push"
	    Lägg till ytterligare en till stad "Berlin" mha "push" 
	    Skriv ut "Det finns XXX städer i arrayen"
	    Plocka ut den andra och fjärde staden i listan. Skriv ut "Mina favoritstäder är Göteborg och Krakow"
    */


}

function arr4() {

    /*
	    Skapa en array "cities" med städerna Stockholm, Göteborg och New York
	    Använd "pop" för att plocka ut den sista staden och placera i en variabel "poppedCity"
	    Skriv ut längen av listan (2)
	    Skriv ut den poppade staden (New York)
	    Använd cities.length för att plocka ut det sista elementet i listan (Göteborg)
    */

}

function arr5() {

    /*
	    Skapa en array "numbers" med talen 5,66,777,12
	    Skriv ut antalet nummer i listan (4)
	    Skriv ut det tredje numret i listan (777)
    */

}

// Extra
function arr6() {

    /*
	    Skapa en array "numbers" med talen 5,66,777,12
        Sortera talen genom att skriva: numbers.sort();
	    Sortera talen genom att skriva: numbers.sort( (a,b) => a-b );
	    Skriv ut värdet av "numbers"
        Jämför de två resultaten
    */

}

// Extra
function arr7() {

    /*
        Sortera listan baklänges
    */
    let numbers = [5, 66, 777, 12];

}

// Extra
function arr8() {

    /*
	    Skapa en array "numbers" med talen 5,66,777,12
	    Vänd på ordningen mha "reverse"
	    Skriv ut arrayen ([ 12, 777, 66, 5 ])
    */


}