
// console.log + fel
console.log('Tjena!');


// sätt och skriv ut varibel
//let name = 'Dan\'s Jansson';
//let name = "Dan's Jansson";
//let name = 'Dan "ironman" Jansson';
let name = "Dan \"ironman\" Jansson";
console.log('Hejsan svejsan ' + name);


// summera två tal. fast strängar. parseInt
let a = 5;
let b = "15";
console.log(a + b);
console.log(a + parseInt(b));


// snefnutt
let name2 = `Dan Jansson`;
console.log('Hejsan svejsan ' + name2);

//let s = "Ditt " + name2 + " namn är " + name2;
let s = `Ditt ${name2} namn är ${name2}`
console.log(s);
//alert(s);
//confirm(s);


// typeof 
let a1 = 1;
let b1 = "2";
let c1 = true;
let d1 = function () { alert('hej!') };
let e1 = [4, 5, 6];
let f1 = { firstName: "Lisa" };

//a = "KALLE"

console.log(typeof a1);
console.log(typeof b1);
console.log(typeof c1);
console.log(typeof d1);
console.log(typeof e1);
console.log(typeof f1);
