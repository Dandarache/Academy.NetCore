

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

function clickAddNews() {
    (async () => {
        const rawResponse = await fetch('https://httpbin.org/post', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ a: 1, b: 'Textual content' })
        });
        const content = await rawResponse.json();

        console.log(content);
    })();
}

function render() {
    let html = "<table>";
    html += `<tr><th>Id</th><th>Header</th><th>Category</th><th>Created</th><th>Updated</th><th>Update</th><th>Delete</th></tr>`;
    for (let news of allNews) {
        html += `<tr>
                    <td>${news.id}</td>
                    <td>${news.header}</td>
                    <td>${news.category === null ? "" : news.category.name}</td>
                    <td>${news.createdDate}</td>
                    <td>${news.updatedDate}</td>
                    <td><button onclick="showUpdateNewsForm(${news.id})">Update</button></td>
                    <td><button onclick="deleteNews(${news.id})">X</button></td>
                 </tr>`;
    }
    html += "</table>";

    document.getElementById("newsList").innerHTML = html;
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