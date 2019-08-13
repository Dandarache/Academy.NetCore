let errorMessages = [];
let result = "";

function render() {
    document.getElementById("error").innerHTML = errorMessages.join("<br>");
    document.getElementById("result").innerText = result;
}

function isInteger(x) {

    return x === parseInt(x);
}
async function squareRoot() {
    errorMessages = [];
    result = "";

    let number = document.getElementById("number").value;
    let nrOfDigits = document.getElementById("nrOfDigits").value;
    let validateOnClientIsChecked = document.getElementById("validateOnClient").checked;

    if (validateOnClientIsChecked) {

        if (!isInteger(number))
            errorMessages.push("Client: Enter a number");
        else if (number < 0)
            errorMessages.push("Client: Can't square root negative numbers");

        if (!isInteger(nrOfDigits)) 
            errorMessages.push("Client: Enter number of digits");
        else if (nrOfDigits < 0)
            errorMessages.push("Client: Number of digits must be greater than 0");

        if (errorMessages.length>0) {
            render();
            return;
        }
    }

    let url = `api/squarerootextra?number=${number}&nrOfDigits=${nrOfDigits}`;

    let response = await fetch(url);

    if (response.status === 200) {

        result = await response.json();
        errorMessages = [];

    }  else if (response.status === 400) {

        result = "";
        errorMessages = await response.json();
        alert(errorMessages.join('<br />'));
        console.log("errorMessages", errorMessages);
    } else {
        result = "";
        errorMessages = `Unexpected(status code = ${ response.status })`;
    }
    render();

}
