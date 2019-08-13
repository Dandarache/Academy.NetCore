// Syfte: kod utan await och async

let errorMessage = "";
let result = "";

function render() {
    document.getElementById("error").innerText = errorMessage;
    document.getElementById("result").innerText = result;
}

function squareRoot() {

    let number = document.getElementById("number").value;

    fetch('api/squareroot?number=' + number).then(response => {

        if (response.status === 200) {

            response.json().then(r => {
                result = r;
                errorMessage = "";
                render();
            });

        } else if (response.status === 400) {

            response.text().then(x => {
                result = "";
                errorMessage = x;
                render();
            });

        } else {
            result = "";
            errorMessage = "Unexpected (status code=" + response.status+")";
            render();
        }

    });
}
