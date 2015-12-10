var serverAddr = "http://localhost:50785/halo";

function addPlayerToDatabase() {
    $.ajax(serverAddr, {
        method: "POST",
        processData: false,
        contentType: 'application/json',
        success: handleServerEvent,
        error: displayErrMsg,
        data: JSON.stringify({
            Name: document.getElementById('name').value,
            Character: document.getElementById('character').value,
            Weapon: document.getElementById('weapon'),
            Game: document.getElementById('game').value
        })
    });
}

function deletePlayer() {
    var nameTxt = document.getElementById('name').value;
    if (nameTxt == null) { return; }
    $.ajax(serverAddr + "/" + nameTxt, {
        method: "DELETE",
        processData: false,
        success: handleServerEvent,
        error: displayErrMsg
    });
}

function getDatabaseData() {
    var tmpURL = serverAddr;
    var nameTxt = document.getElementById('name').value;
    if (nameTxt != "") { tmpURL += "/" + nameTxt; }
    $.ajax(tmpURL, {
        method: "GET",
        success: handleServerEvent,
        error: displayErrMsg
    });
}

function editPlayerInfo() {
    $.ajax(serverAddr + "/" + document.getElementById('name').value, {
        method: "PATCH",
        contentType: "application/json",
        //processData: false,
        success: handleServerEvent,
        error: displayErrMsg,
        data: JSON.stringify({
            Name: document.getElementById('name').value,
            Character: document.getElementById('character').value,
            Weapon: document.getElementById('weapon').value,
            Game: document.getElementById('game').value
        })
    });
}

function handleServerEvent(data, data2, data3) {
    resetTextFields();
    var resultsDiv = document.getElementById("results");
    resultsDiv.style.color = 'BLACK';
    resultsDiv.textContent = JSON.stringify(data);
}

function displayErrMsg(data) {
    resetTextFields();
    document.getElementById('results').textContent = "An error has occurred with status code: \"" + data["status"] + "\"\n\nDetails: " + data["statusText"];
    document.getElementById('results').style.color = 'RED';
}

function resetTextFields() {
    var nameTF = document.getElementById('name');
    var characterTF = document.getElementById('character');
    var weaponTF = document.getElementById('weapon');
    var gameTF = document.getElementById('game');
    clearTextField(nameTF);
    clearTextField(characterTF);
    clearTextField(weaponTF);
    clearTextField(gameTF);
}

function clearTextField(textField) {
    if (textField == "") { return; }
    textField.value = "";
}
