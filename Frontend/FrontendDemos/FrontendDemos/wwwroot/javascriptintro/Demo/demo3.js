// forloop

for ( let i=5; i<=8; i++) {
    console.log('Ett tal '+ i);
    console.log('HEJ!!!');
}

// while loop

let kalle=5;

while(kalle<=8) {
    console.log(kalle);
    kalle = kalle + 1;
}

// for of

let cities = ['Stockholm', 'Göteborg', 'New York'];

for (let x of cities) {
    console.log("Fin stad: " + x);
}
// for of med break

let cities = ['Stockholm', 'Göteborg', 'New York', 'Amsterdam', 'Dublin'];

// =     tilldelar ett värde
// ===    jämför

for (let x of cities) {
    if (x === "Göteborg") {
        break;
    }
    console.log("Fin stad: " + x);

}
