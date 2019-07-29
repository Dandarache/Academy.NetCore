//läggTillTre(4);
//läggTillTre(4.2);
//läggTillTre("5");
//läggTillTre([1, 2, 3]);

//iLikeData();
//iLikeDataWithBorder(false);
//iLikeDataWithBorder("");
//iLikeDataWithBorderAndRepeat(true, '+');

//let minaFarger = ['rött', 'blått', 'grönt'];
//skrivUtListan(minaFarger);

television("sVt1");

//--------------------

// 


function läggTillTre(x) {
    let result = x + 3;
    console.log(result);
}

// funktion (som kan anropas flera gånger)

function iLikeData() {
    console.log("------- JAG GILLAR DATA! ------");
}

// funktion med parameter

function iLikeDataWithBorder(addBorder) {
    if (addBorder) {
        console.log("-------------------------------");
    } 
    console.log("------- JAG GILLAR DATA! ------");

    if (addBorder) {
        console.log("-------------------------------");
    }
}

// funktion med flera parametrar

function iLikeDataWithBorderAndRepeat(addBorder, borderChar) {
    if (addBorder) {
        console.log(borderChar.repeat(31) );
    }

    console.log(borderChar + "       JAG GILLAR DATA!      " + borderChar);

    if (addBorder) {
        console.log(borderChar.repeat(31));
    }
}

// Lista som en parameter

function skrivUtListan(lista) {

    console.log("EN LISTA!");
    for(let x of lista) {
        console.log("* " + x);
    }
}

// includes och toUpperCase

function television(x) {
    if (["SVT1", "SVT2", "TV4"].includes(x.toUpperCase()))
        console.log("Mmmm denna kanal känner jag till");
    else
        console.log("Vad är detta för kanal??");
}




