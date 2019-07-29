function starify(str) {
    let result = []
    for (let i = 0; i < str.length; i++) {
        let c = str[i]
        result.push("*" + c + "*")
    }
    return result
}
function starify_forIn(str) {
    let result = []
    for (let i in str) {
        let c = str[i]
        result.push("*" + c + "*")
    }
    return result
}

function starify_forOf(str) {
    let result = []
    for (let c of str) {
        result.push("*"+c+"*")
    }
    return result
}

function starify_map(str) {
    return [...str].map(s => "*" + s + "*");
}

function addOneToEachNumber(x) {
    if (x === null)
        return null
    let result = []
    for (let number of x) {
        result.push(number + 1)
    }
    return result
}

function addOneToEachNumber_map(x) {
    if (x === null)
        return null
    return x.map(n => n + 1);
}

function putTheLastElementFirst(arr) {
    if (arr.length === 0) return []
    let first = arr.splice(arr.length-1)
    let rest = arr.splice(0, arr.length)
    return first.concat(rest)
}

function putTheLastElementFirst_pop(arr) {

    if (arr.length === 0) return []
    let last = arr.pop()
    return [last].concat(arr)
}

function supersum() {
    let result = 0
    let x = arguments[0]
    let y = arguments[1]
    for (let i = 2; i < arguments.length; i++) {
        result += arguments[i]
    }
    if (arguments.length <= 2) result = "";

    return x + result + y;
}

function supersum_spread(x, y, ...arr) {
    let result = 0;
    for (const n of arr) {
        result = result + n;
    }
    if (x === null) x = "";
    if (y === null) y = "";

    if (arr.length === 0) result = "";

    return x + result + y;
}

function someUpperCase(wordList, upperList) {
    if (wordList.length !== upperList.length)
        return null;

    let result = []
    for (let i = 0; i < wordList.length; i++) {
        if (upperList[i])
            result.push(wordList[i].toUpperCase())
        else
            result.push(wordList[i])
    }
    return result;
}

function someUpperCase_map(wordList, upperList) {
    if (wordList.length !== upperList.length)
        return null;

    return wordList.map((x, i) => {
        if (upperList[i])
            return x.toUpperCase()
        else
            return x
    })
}
