fun1();
fun2();
fun3();
fun4();

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
        console.log("--------");
        console.log("-------- VÄLKOMMEN");
        console.log("--------");
        console.log("");
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

    function sayHiTo(ettnamn) {
        console.log("--------");
        console.log(`-------- VÄLKOMMEN ${ettnamn.toUpperCase()}`);
        console.log("--------");
        console.log("");
    }

    sayHiTo('Dan');
    sayHiTo('Musse');
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
        if (age >= 18) {
            console.log(`${name} är myndig`);
        } else {
            console.log(`Obs! ${name} är inte myndig!`);
        }
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
        let vat = price * 0.25;
        console.log(`Momsen för varan är ${vat}kr`);
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
        console.log(`FÖR ATT GÖRA ${recipeName.toUpperCase()} BEHÖVS:`);
        for (let item of ingredients) {
            console.log(`* ${item.toUpperCase()}`);
        };

        console.log("");
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
        let vatPercentage = 0.25;
        let twelvePercent = ["livsmedel", "restaurangbesök", "hotell", "konstverk"];
        let sixPercent = ["tidning", "bok", "taxi", "buss", "flyg", "tåg", "konsert"];
        if (twelvePercent.includes(typeOfProduct))
            vatPercentage = 0.12;

        if (sixPercent.includes(typeOfProduct))
            vatPercentage = 0.06;

        let vat = price * vatPercentage;
        console.log(`Momsen för en/ett ${typeOfProduct} som kostar ${price}kr är ${vat}kr`)
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
        let vatPercentage = 0.25;
        let twelvePercent = ["livsmedel", "restaurangbesök", "hotell", "konstverk"];
        let sixPercent = ["tidning", "bok", "taxi", "buss", "flyg", "tåg", "konsert"];
        if (twelvePercent.includes(typeOfProduct))
            vatPercentage = 0.12;

        if (sixPercent.includes(typeOfProduct))
            vatPercentage = 0.06;

        let vat = price * vatPercentage;
        console.log(`Momsen för ${prefix} ${typeOfProduct} som kostar ${price}kr är ${vat}kr`)
    }

    skrivUtMoms("en", "tidning", 1000);
    skrivUtMoms("ett", "restaurangbesök", 1000);
    skrivUtMoms("ett", "flyg", 1000);
    skrivUtMoms("en", "falafel", 1000);
    skrivUtMoms("en", "hipsteröl", 1000);

}
