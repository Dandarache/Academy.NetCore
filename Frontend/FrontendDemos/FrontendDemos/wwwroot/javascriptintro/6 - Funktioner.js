
function fun1() {

    /*
        Gör en metod "sayHi". Anropa den två gånger
    
        sayHi()
        sayHi()

    Detta ska skrivas ut:

    --------
    -------- VÄLKOMMEN 
    --------

    --------
    -------- VÄLKOMMEN 
    --------

    */

    function sayHi() {
    }

    sayHi();
    sayHi();
}

function fun2() {

    /*
    Liknande som sist men gör en metod sayHiTo() som tar ett namn som inparameter.

    Ex sayHiTo("Dan") ska skriva ut:

    --------
    -------- VÄLKOMMEN DAN
    --------

    */


    sayHiTo('Dan');
    sayHiTo('Laban');
}

function fun3() {

    /*
    Gör en metod "myndig" med två parameterar "name" och "age". Anropa den tre gånger
    
        myndig("Peter", 16);
        myndig("Lisa", 26);
        myndig("Ragnar", 15);

    Detta ska skrivas ut:

        Obs! Peter är inte myndig!
        Lisa är myndig
        Obs! Ragnar är inte myndig!
    */

    function myndig(name, age) {
    }

    myndig("Peter", 16);
    myndig("Lisa", 26);
    myndig("Ragnar", 15);

}

function fun4() {

    /*
    Gör en metoden "skrivUtMoms" som tar "price" som inparameter.
    Om du t.ex anropas metoden såhär:

        skrivUtMoms(1000)

    ...så ska detta skrivas ut:

        Momsen för varan är 250kr

    */

    function skrivUtMoms(price) {
    }

    skrivUtMoms(1000);
    skrivUtMoms(400);
}

// -------- EXTRA UPPGIFTER -----------------------------------------


function extraFun2() {

    /*

    Gör en metod "recept" med en parameter "recipeName" och "ingredients". Anropa den:
    
        recept("Äpplekaka", ["Äpple", "Mjöl", "Kanel"]);
        recept("Rotmos", ["Potatis", "Kålrot"]);

    Detta ska skrivas ut:

        FÖR ATT GÖRA ÄPPLEKAKA BEHÖVS:
        * ÄPPLE
        * MJÖL
        * KANEL

        FÖR ATT GÖRA ROTMOS BEHÖVS:
        * POTATIS
        * KÅLROT
    */

    function recept(recipeName, ingredients) {
    }

    recept("Äpplekaka", ["Äpple", "Mjöl", "Kanel"]);
    recept("Rotmos", ["Potatis", "Kålrot"]);
}

function extraFun3() {

    /*

    I sverige finns tre momssatser: 25%, 12% och 6%. Se här:
    https://www.verksamt.se/starta/skatter-och-avgifter/moms/olika-momssatser

    Skriv en metod "skrivUtMoms" som beräknar moms på en vara utifrån vilken typ av vara det är

    Dessa anrop:

        skrivUtMoms("tidning", 1000);
        skrivUtMoms("restaurangbesök", 1000);
        skrivUtMoms("flyg", 1000);
        skrivUtMoms("falafel", 1000);
        skrivUtMoms("hipsteröl", 1000);

    Ska ge svaren:

        Momsen för en/ett tidning som kostar 1000kr är 60kr
        Momsen för en/ett restaurangbesök som kostar 1000kr är 120kr
        Momsen för en/ett flyg som kostar 1000kr är 60kr
        Momsen för en/ett falafel som kostar 1000kr är 250kr
        Momsen för en/ett hipsteröl som kostar 1000kr är 250kr

    */

    function skrivUtMoms(typeOfProduct, price) {
    }

    skrivUtMoms("tidning", 1000);
    skrivUtMoms("restaurangbesök", 1000);
    skrivUtMoms("flyg", 1000);
    skrivUtMoms("falafel", 1000);
    skrivUtMoms("hipsteröl", 1000);

}

function extraFun4() {

    /*

    Modifiera "skrivUtMoms" så det går att ange "en" eller "ett".

    Dessa anrop:

        skrivUtMoms("en", "tidning", 1000);
        skrivUtMoms("ett", "restaurangbesök", 1000);
        skrivUtMoms("ett", "flyg", 1000);
        skrivUtMoms("en", "falafel", 1000);
        skrivUtMoms("en", "hipsteröl", 1000);

    Ska ge svaret:

        Momsen för en tidning som kostar 1000kr är 60kr
        Momsen för ett restaurangbesök som kostar 1000kr är 120kr
        Momsen för ett flyg som kostar 1000kr är 60kr
        Momsen för en falafel som kostar 1000kr är 250kr
        Momsen för en hipsteröl som kostar 1000kr är 250kr

    */

    function skrivUtMoms(prefix, typeOfProduct, price) {
    }

    skrivUtMoms("en", "tidning", 1000);
    skrivUtMoms("ett", "restaurangbesök", 1000);
    skrivUtMoms("ett", "flyg", 1000);
    skrivUtMoms("en", "falafel", 1000);
    skrivUtMoms("en", "hipsteröl", 1000);

}
