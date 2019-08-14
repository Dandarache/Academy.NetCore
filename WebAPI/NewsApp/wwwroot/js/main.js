
async function clickRecreate() {
    //alert("clickRecreate()");

    let recreateButton = document.getElementById('recreateButton');
    recreateButton.disabled = true;

    let response = await fetch('api/news/recreate', {
        method: 'POST'
    });

    if (response.status === 204) {
        alert("Database Recreated");

        // ...
    }
    else {
        console.log('Något vart fel: ' + response);
    }

    recreateButton.disabled = false;

}