var siteURL = "http://localhost:50785/";

function forcePushFunc() {
    $.ajax(siteURL, {
        Method: "POST",
        ProcessData: false,
        Data: {
            Name: document.getElementById("name"),
            Preference: document.getElementById("preference")
        },
        Success: handleServerEvent
    });
}

function forceGetFunc() {
    $.ajax(siteURL, {
        Method: "GET",
        Success: handleServerEvent
    })
}

function handleServerEvent(data, data2, data3) {
    var resultsDiv = document.getElementById("results");
    resultsDiv.textContent = JSON.stringify(data);
}
