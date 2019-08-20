
// Globala variabler som hanterar tillståndet i JavaScript-applikationen, dvs SPA.
let state = {
    allCategories: [],
    allNews: [],
    activeArea: null, // Vilken yta som visas under tabellen (ex addArea)
    updateArea: null,
    addArea: null
};

// Funktionsanrop som gör att data hämtas och uppdateras då sidan laddats.
init();

////////////////////////////////////////////////////
// Funktion som anropas när sidan laddas
////////////////////////////////////////////////////

async function init() {

    await updateAll();
}

////////////////////////////////////////////////////
// Funktioner renderar och uppdaterar gränsnittet
////////////////////////////////////////////////////

function render() {
    // Uppdatera gränsnittet utifrån "state". Denna gör inga ajaxanrop.

    // Nyhetstabellen

    let html = "<table>";
    html += `<tr><th>Id</th><th>Header</th><th>Category</th><th>Created</th><th>Updated</th><th>Update</th><th>Delete</th></tr>`;
    for (let news of state.allNews) {
        html += `<tr>
                    <td>${news.id}</td>
                    <td>${news.header}</td>
                    <td>${news.category === null ? "" : news.category.name}</td>
                    <td>${formatDate(news.createdDate)}</td>
                    <td>${formatDate(news.updatedDate)}</td>
                    <td><button onclick="showUpdateNewsForm(${news.id})">Update</button></td>
                    <td><button onclick="deleteNews(${news.id})">X</button></td>
                 </tr>`;
    }
    html += "</table>";

    byId("newsList").innerHTML = html;

    // Areor

    byId("addArea").style.display = "none";
    byId("updateArea").style.display = "none";
    byId("statArea").style.display = "none";

    if (state.activeArea !== null)
        byId(state.activeArea).style.display = "block";

    // Category dropdown

    fillDropdown("addAreaCategory", state.allCategories, "id", "name");
    fillDropdown("updateAreaCategory", state.allCategories, "id", "name");

    // Statistik
    byId("nrOfNews").innerText = state.allNews.length;

    // Formulär för uppdatera nyhet
    if (state.updateArea !== null) {
        byId("updateAreaId").value = state.updateArea.id;
        byId("updateAreaHeader").value = state.updateArea.header;
        byId("updateAreaIntro").value = state.updateArea.intro;
        byId("updateAreaBody").value = state.updateArea.body;
        byId("updateAreaCategory").value = state.updateArea.selectedCategory;
        byId("updateAreaError").innerHTML = state.updateAreaError;
    }

    // Formulär för lägg till nyhet
    if (state.addArea !== null) {
        byId("addAreaHeader").value = state.addArea.header;
        byId("addAreaIntro").value = state.addArea.intro;
        byId("addAreaBody").value = state.addArea.body;
        byId("addAreaCategory").value = state.addArea.selectedCategory;
        byId("addAreaError").innerHTML = state.addAreaError;
    }
}

function clickShowAddNews() {
    state.addAreaError = null;
    state.activeArea = "addArea";
    render();
}

function clickStatArea() {
    state.activeArea = "statArea";
    render();
}

////////////////////////////////////////////////////
// Funktioner anropar webapi.
////////////////////////////////////////////////////

async function clickRecreate() {
    //alert("clickRecreate()");

    let recreateButton = document.getElementById('recreateButton');
    recreateButton.disabled = true;

    let response = await fetch('api/news/recreate', {
        method: 'POST'
    });

    if (response.status === 204) {
        alert("Database Recreated");
        await updateAll();
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
        await updateAll();
    }
    else {
        console.log('Something went wrong: ' + response);
    }

    seedButton.disabled = false;

}

async function clickAddNews() {

    state.addArea = {};
    state.addArea.header = byId("addAreaHeader").value;
    state.addArea.intro = byId("addAreaIntro").value;
    state.addArea.body = byId("addAreaBody").value;
    state.addArea.selectedCategory = getSelectedValue("addAreaCategory");

    let response = await fetch("api/News", {
        method: "POST",
        body: JSON.stringify(
            {
                header: state.addArea.header,
                intro: state.addArea.intro,
                body: state.addArea.body,
                category: {
                    id: state.addArea.selectedCategory
                }
            }),
        headers: {
            "Content-Type": "application/json"
        }
    });

    if (response.status === 200) {
        state.addAreaError = null;
        state.addArea.header = "";
        state.addArea.intro = "";
        state.addArea.body = "";
        await updateNewsTable();

        state.activeArea = null;
        render();


    } else if (response.status === 400) {
        state.addAreaError = errorList(await response.json());

    } else {
        console.log("Unexpected error", response);
    }
    render();

}

async function clickUpdateNews() {

    state.updateArea = {}
    state.updateArea.id = byId("updateAreaId").value;
    state.updateArea.header = byId("updateAreaHeader").value;
    state.updateArea.intro = byId("updateAreaIntro").value;
    state.updateArea.body = byId("updateAreaBody").value;
    state.updateArea.selectedCategory = getSelectedValue("updateAreaCategory");

    let response = await fetch("api/News", {
        method: "PUT",
        body: JSON.stringify(
            {
                id: state.updateArea.id,
                header: state.updateArea.header,
                intro: state.updateArea.intro,
                body: state.updateArea.body,
                category: {
                    id: state.updateArea.selectedCategory
                }
            }),
        headers: {
            "Content-Type": "application/json"
        }
    });

    if (response.status === 204) {
        state.updateAreaError = null;
        state.updateArea.id = "";
        state.updateArea.header = "";
        state.updateArea.intro = "";
        state.updateArea.body = "";
        await updateNewsTable();

        state.activeArea = null;
        render();

    } else if (response.status === 400) {
        state.updateAreaError = errorList(await response.json());

    } else if (response.status === 404) {
        console.log(`News with id = ${state.updateArea.id} not found`);
    } else {
        console.log("Unexpected error", response);
    }
    render();
}

async function deleteNews(id) {

    let response = await fetch("api/News/" + id, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json"
        }
    });

    if (response.status === 204) {

        await updateNewsTable();
    } else if (response.status === 404) {
        console.log(`News with id = ${id} not found`);
    } else {
        console.log("Unexpected error", response);
    }

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
        console.log('Unexpected error: ' + response);
    }
}

async function updateCategories() {

    let response = await fetch("api/categories", {
        method: "GET"
    });

    if (response.status === 200) {
        state.allCategories = await response.json();
    } else {
        console.log("Unexpected error", response);
    }

}

async function showUpdateNewsForm(id) {
    state.updateAreaError = null;

    let response = await fetch("api/News/" + id, {
        method: "GET"
    });

    if (response.status === 200) {

        state.activeArea = "updateArea";
        state.updateArea = await response.json();

        if (state.updateArea.category == null)
            state.updateArea.selectedCategory = null;
        else
            state.updateArea.selectedCategory = state.updateArea.category.id; // lite fult
        render();
    } else {
        console.log("Unexpected error: ", response);
    }
}

async function updateNewsTable() {

    let response = await fetch("api/News", {
        method: "GET"
    });

    if (response.status === 200) {
        state.allNews = await response.json();
        render();
    } else {
        console.log("Unexpected error", response);
    }

}

////////////////////////////////////////////////////
// Hjälpfunktioner som underlättar och förenklar koden.
////////////////////////////////////////////////////

async function updateAll() {
    await updateNewsTable();
    await updateCategories();
    state.activeArea = null;
    render();
}

function getSelectedValue(id) {
    let selector = byId(id);
    if (selector.selectedIndex === -1)
        return null;

    return selector[selector.selectedIndex].value;
}

function fillDropdown(id, list, valuePropName, textPropName) {
    byId(id).innerHTML = "";
    // list = [{ id: "", name: "" }].concat(list);
    for (let item of list) {
        let option = document.createElement("option");
        option.text = item[textPropName];
        option.value = item[valuePropName];
        byId(id).add(option);
    }
}

function formatDate(date) {
    return date.slice(0, 19).replace("T", " ");
}

function errorList(response) {

    var errList = [];

    if (response.Header) {
        errList.push(response.Header[0]);
    }

    if (response.Intro) {
        errList.push(response.Intro);
    }

    if (response.Body) {
        errList.push(response.Body);
    }

    return errList.join("<br><br>");

}

function byId(id) {
    return document.getElementById(id);
}