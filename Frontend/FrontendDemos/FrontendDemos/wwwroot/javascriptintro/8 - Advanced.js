
/*
 Tips: kolla på http://es6-features.org

 Todo: övning om new Map()
 */


function loglist(listname, list) {
    console.log('***' + listname + '***');
    for (let x of list)
        console.log(x);
}

function adv1() {

    const evens = [2, 4, 6, 8];

    // Använd "map" för att skapa en ny lista "odds" utifrån listan "evens"
    const odds = evens.map(n => n + 1);

    loglist("adv1", odds);

}

function adv2() {

    const evens = [2, 4, 6, 8];

    // Använd "map" för att skapa en ny lista "--2--", "--4--", "--6--", "--8--"
    const list = evens.map(n => "--" + n + "--");

    loglist("adv2", list);

}

function adv3() {

    const evens = [2, 4, 6, 8];

    // Använd "map" för att skapa en ny lista [{row:1, num:200}, {row:2, num:400} ...]
    const list = evens.map((n, index) => ({ row: index + 1, num: n * 100 })); // de båda yttre paranteserna krävs

    loglist("adv3", list);

}


function adv4() {

    const evens = [2, 4, 6, 8];
    // Använd "forEach" för att skriva ut alla element i listan
    evens.forEach(n => console.log(n));

    // Använd "forEach" för att skriva ut:
    //Element 0) 2
    //Element 1) 4
    //Element 2) 6
    //Element 3) 8

    evens.forEach((n, index) => 
        console.log(`Element ${index}) ${n}`)
    );

}

function adv5() {

    // Gör om metoden så default för a är 30 och b är 40. 
    // alltså om t.ex sum(15) anropas så returneras 55
    function sum(a, b) {
        return a + b;
    }

    function sumX(a = 30, b = 40) {
        return a + b;
    }
    console.log(sumX());    // 70
    console.log(sumX(1));   // 41
    console.log(sumX(1, 2)); // 3

}

function adv6() {

    // Skapa en funktion "sum" som summerar valfritt antal tal
    // Ex sum(2, 10, 3) ska returnera 15
    // Ex sum(2, 10) ska returnera 12
    // Använd "spread operator"
    function sum(...arr) {
        let result = 0;
        for (const n of arr) {
            result += n;
        }
        return result;
    }

    console.log(sum(2, 10, 3));
    console.log(sum(2, 10));
}

function adv7() {

    /* Skapa en funktion "supersum" som ska funkar såhär:
   
       supersum("<", ">", 3, 4, 5);  ==>  "<12>"
       supersum("[", "]", 55, 2)     ==>  "[57]"
       supersum("A", "B", 6)         ==>  "A6B"

    */
    function supersum(x, y, ...arr) {
        let result = 0;
        for (const n of arr) {
            result = result + n;
        }
        return x + result + y;
    }

    console.log(supersum("<", ">", 3, 4, 5));
    console.log(supersum("[", "]", 55, 2));
    console.log(supersum("A", "B", 6));

}

function adv8() {

    /*
     Skapa metoden "starify" som ska funka såhär:

     starify("ab")           ==>   ["*a*", "*b*"]
     starify("XYZ")          ==>   ["*X*", "*Y*", "*Z*"]

    Använd "map" och "spread operator"
     */
    function starify(str) {
        return [...str].map(s => "*" + s + "*");
    }

    console.log(starify("ab"));
    console.log(starify("XYZ"));
}

function adv9() {

    let firstName = "Simon";
    let lastName = "Larsson";

    // Skapa objektet {firstName: "Simon", lastName: "Larsson"} på enklast möjliga sätt

    let person = { firstName, lastName };
    console.log(person);
}

function adv10() {
    /*
     Skapa ett objekt "myMath" som rymmer metoderna "addOne" och "double":

        myMath.addOne(100)   ==>   101
        myMath.double(100)   ==>   200
     */
    let myMath = {
        addOne(x) {
            return x + 1;
        },
        double(x) {
            return 2 * x;
        }
    };

    console.log(myMath.addOne(100));
    console.log(myMath.double(100));

}

function adv11() {

    let x = 100;
    let y = 200;

    // Sätt x till y och y till x med "array matching"

    [y, x] = [x, y]; // Det skapas ingen array. Det är bara x och y som förändras

    console.log("x", x); // 200
    console.log("y", y); // 100

}

function adv12() {

    let list = [10, 20, 30, 40, 50];
    // Sätt a till 10, b till 30 och c till 40 mha "array matching" 

    let [a, , b, c] = list;

    console.log("a", a); // 10
    console.log("b", b); // 30
    console.log("c", c); // 40

}


function adv13() {
    function getPerson() {
        return { firstName: 'Lisa', age: 66 };
    }

    // Sätt "firstName" till "Lisa" och "age" till "66" genom att anropa "getPerson" och använda "object matching"

    let { firstName, age } = getPerson();

    console.log("firstName", firstName);
    console.log("age", age);

}

function adv14() {

    function fun({ firstName: f, age: a }) {
        console.log("f", f);
        console.log("a", a);
    }

    // Skapa en funktion som skriver ut "Lisa" och 66 utifrån "person"
    // Använd "Parameter Context Matching"
    let person = { firstName: 'Lisa', age: 66, favColor: "red" };
    fun(person);

}
function adv15() {
    /*
        Skapa en klass "Shape" som kan användas såhär:

        let s = new Shape(1111, 4, 5);
        s.display();
        s.move(100, 200);
        s.display();

        let s2 = Shape.defaultShape(); // Ska gen en shape med id=5000, x=999 och y=888
        s2.display();

        console.log(s.highest);
        console.log(s2.highest);

        Koden ovan ska skriva ut följande i konsolen:

        Id: 1111 Position:(4,5)
        Id: 1111 Position:(100,200)
        Id: 5000 Position:(999,888)
        200
        99
     */

    class Shape {
        constructor(id, x, y) {
            this.id = id;
            this.move(x, y);
        }
        move(x, y) {
            this.x = x;
            this.y = y;
        }
        display() {
            console.log(`Id: ${this.id} Position:(${this.x},${this.y})`);
        }

        static defaultShape() {
            return new Shape(5000, 999, 888);
        }

        get highest() { return Math.max(this.x, this.y);}
    }

    let s = new Shape(1111, 4, 5);
    s.display();
    s.move(100, 200);
    s.display();

    let s2 = Shape.defaultShape();
    s2.display();

    console.log(s.highest);
    console.log(s2.highest);

    // Diverse
    console.log("aaa", s.aaa); // undefined
    // console.log("aaa", s.aaa.bbb ); //  ger exception

}

function adv16() {

    /*
        Skapa en oändlig lista av udda tal "odds" genom att använda [Symbol.iterator]

        Detta ska ge alla udda tal upp till 13:

        for (let n of odds) {
            console.log(n);
            if (n >= 13)
                break;
        }

     */ 

    let odds = {
        [Symbol.iterator]() { // [System.iterator] krävs
            let number = 1;
            return {
                next() { // next() krävs
                    let toReturn = { value: number }; // måste vara ett objekt som innehåller "value"
                    number += 2;
                    return toReturn;
                }
            };
        }
    };

    let odds2 = {
        *[Symbol.iterator]() { // Generator funktion => enklare!
            let number = 1;
            while (true) {
                yield number;
                number += 2;
            }
        }
    };

    for (let n of odds) {
        console.log(n);
        if (n >= 13)
            break;
    }

    for (let n of odds2) {
        console.log(n);
        if (n >= 7)
            break;
    }
}

function adv17() {
    /*
    Skapa en metod "range" som ger alla tal med en viss steglängd

    Ex 

    for (let x of range(10, 30, 4))
        console.log(x);

    ...ska 
     */
    function* range(start, end, step) {
        while (start <= end) {
            yield start;
            start += step;
        }
    }

    for (let x of range(10, 30, 4))
        console.log(x);

}

function adv18() {
    const data = [5, 10, 15, 20, 25];

    const res = data.reduce((total, currentValue) => {
        return total + currentValue;
    });

    const data2 = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

    const flatValues = data2.reduce((total, value) => {
        return total.concat(value);
    }, []);

    var maxCallback = (acc, cur) => Math.max(acc.x, cur.x);
    [{ x: 22 }, { x: 42 }].reduce(maxCallback); // 42
}

function adv19() {
    var names = ['Alice', 'Bob', 'Tiff', 'Bruce', 'Alice'];

    var countedNames = names.reduce(function (allNames, name) {
        if (name in allNames) {
            allNames[name]++;
        }
        else {
            allNames[name] = 1;
        }
        return allNames;
    }, {});
// countedNames is:
// { 'Alice': 2, 'Bob': 1, 'Tiff': 1, 'Bruce': 1 }
}