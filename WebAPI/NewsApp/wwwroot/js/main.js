

let allNews = [];

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

async function clickSeed() {

    let seedButton = document.getElementById('seedButton');
    seedButton.disabled = true;

    let response = await fetch('api/news/seed', {
        method: 'POST'
    });

    if (response.status === 204) {
        alert("Data added by seed function.");

        // ...
    }
    else {
        console.log('Something went wrong: ' + response);
    }

    seedButton.disabled = false;

}

function clickStatArea() {
    getAllNews();
    render();
}

function render() {

    let html = '';

    for (let news of allNews) {
        html += '<b>' + news.header + '</b><br>';
        console.log(news.header);
    }

    console.log(html);

}

async function getAllNews() {
    //alert('getAllNews()');

    let response = await fetch('api/news', {
        method: 'get'
    });

    if (response.status === 200) {

        let newsList = await response.json();

        //let first = newsList[0];
        //alert(first);        

        allNews = newsList;
    }
    else {
        console.log('Something went wrong: ' + response);
    }
}