
//let area = areaFörEnCirkel(3);
//console.log("Arean på cirkeln är " + area + "m2");

//let result = volymFörCylinder(3, 5);
//console.log("Cylinderns volym är " + result);

//console.log("100 grader motsvarar: " + convertToCelsius(100));
//console.log("50 grader motsvarar: " + convertToCelsius(50));
//console.log("0 grader motsvarar: " + convertToCelsius(0));

//let yourAge = 17;
//if (ärEnPensioner(yourAge)) {
//    console.log("Oj vad gammal du är!");
//} else {
//    console.log("Yngling!");
//}

// funktion som returnerar nåt

function convertToCelsius(far) {
    let c = (far - 32) * 5/9;
    return c;
}

function areaFörEnCirkel(r) {
    let area = r * r * Math.PI; // 3.1415926;
    return area;
}

// funktion som returnerar nåt - flera parametrar
// funktion som använden annan funktion

function volymFörCylinder(r, h) {
    let area = areaFörEnCirkel(r);
    let volym = area* h;
    return volym;
}

function ärEnPensioner(age) {
    if (age>=65)
        return true;
    else
        return false;
}




