// if > = <

// (.. > .. && ...)

let fruit = "banan";
let weight = 120;

let x1 = fruit === "banan" || fruit === "päron";
let x2 = fruit === "banan" || (fruit === "päron" && weight>110);

// switch 


// 10=="10"

// "ternary operator"

let a=5000;
let x = "";

 if (a>1000) {
     x = "a är ett stort tal";
 } else {
     x = "a är ett litet tal";
 }

let x = a>1000 ? "a är ett stort tal" : "a är ett litet tal";

console.log(x);
