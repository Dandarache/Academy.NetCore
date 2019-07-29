function pickEverySecond(list) {
    if (list === null)
        return null

    let result = []

    for (let i = 1; i < list.length; i = i + 2) {
        result.push(list[i])
    }
    return result;
}

function pickEverySecond_withFilter(list) {
    if (list === null) return null;

    return list.filter((el, index) => {
        if (index % 2 === 1) return el;
    });
}   

// The same but shorter
function pickEverySecond_withFilter2(list) {
    if (list === null) return null;

    return list.filter((el, index) => 
        index % 2 === 1 ? el: null
    );
}   

// The same but with one line
function pickEverySecond_withFilter3(list) {

    return list === null ? null : 
        list.filter((el, index) =>
            index % 2 === 1 ? el : null
        );
}   

function tellType(x) {
    let type = typeof x
    if (type === "number") {
        if (x > 100)
            return `A number ${x}. It is greater or equal to 100.`
        else
            return `A number ${x}. Add ${100 - x} and you will get 100.`

    }

    if (type === "boolean") {
        if (x === true)
            return "It is true"
        else
            return "It is false"
    }

    if (type === "string")
        return "Just a string"

    if (type === "undefined")
        return "Not defined"
}

function tellType_switch(x) {
    switch (typeof x) {
        case "number":
            return x > 100 ?
                `A number ${x}. It is greater or equal to 100.` :
                `A number ${x}. Add ${100 - x} and you will get 100.`

        case "boolean":
            return x ? "It is true" : "It is false"

        case "string":
            return "Just a string"

        case "undefined":
            return "Not defined"
    }
}

function tellType_withoutIfOrSwitch(x) {

    let arr = []
    arr["number"] = (a) => a > 100 ?
        `A number ${a}. It is greater or equal to 100.` :
        `A number ${a}. Add ${100 - a} and you will get 100.`

    arr["boolean"] = (a) => a ? "It is true" : "It is false"

    arr["string"] = () => "Just a string"
    arr["undefined"] = () => "Not defined"

    return arr[typeof x](x)
}

function shoppinglist(arr) {
    if (arr.length === 0) return "NOTHING TO BUY"

    let result = "TO BUY: "
    for (let x of arr) {
        result += '* ' + x.toUpperCase() + ' '
    }
    result = result.trim() // not so elegant, we have to remove the extra whitespace
    return result
}

function shoppinglist_map(arr) {
    if (arr.length === 0) return "NOTHING TO BUY"

    let points = arr.map(x => '* ' + x.toUpperCase()).join(' ')
    return "TO BUY: " + points
}

function shoppinglist_oneline(arr) {

    return arr.length === 0 ?
        "NOTHING TO BUY" :
        "TO BUY: " + arr.map(x => '* ' + x.toUpperCase()).join(' ')
}

function createSequence(start, inc, numelements) {
    let result = []

    for (let i = start; i < start + inc * numelements; i += inc)
        result.push(i)

    return result
}

function createSequence_while(start, inc, numelements) {
    let result = []
    let next = start
    while (result.length !== numelements) {
        result.push(next)
        next += inc
    }
    return result
}

function createPerson(f, l, c) {
    let person = {
        firstName: f,
        lastName: l,
        characters: c,
        fullName: function () { return this.firstName + " " + this.lastName; },
        numberOfRoles: function () { return this.characters.length; }

        // This doesn't work:
        //fullName: () => this.firstName + " " + this.lastName,
        //numberOfRoles: () => this.characters.length 

    }
    return person
}

function createPersonGetter(f, l, c) {
    let person = {
        firstName: f,
        lastName: l,
        characters: c,
        get fullName() { return this.firstName + " " + this.lastName; },
        get numberOfRoles() { return this.characters.length; }

        // This doesn't work:
        // get fullName() => this.firstName + " " + this.lastName,

    }
    return person
}
