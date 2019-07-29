
// en array. plocka ut värden (även utanför)

let minaTräd = ["asp", "alm", "gran", "al", "björk"];

console.log(minaTräd);
console.log(minaTräd[0]);
console.log(minaTräd[3]);

// push'a träd

minaTräd.push("ek");
minaTräd.push("tall");

console.log(minaTräd)

// length

console.log("Det finns " + minaTräd.length + " träd")

// pop

let xxx = minaTräd.pop()

console.log(minaTräd)
console.log(xxx)

// sista värdet i en array

let sistaTrädet = minaTräd[minaTräd.length-1]
console.log(sistaTrädet)

// sortera med sort ()

minaTräd.sort()
console.log(minaTräd)