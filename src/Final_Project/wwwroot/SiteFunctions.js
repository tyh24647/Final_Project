﻿//var serverAddr = "http://tyhostager-final-project.azurewebsites.net/halo";
var serverAddr = "http://localhost:55066/halo";
var loginAddr = "http://localhost:55066/login";

function addPlayer() {
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

/*
function loginUser() {
    $.ajax(loginAddr, {
        method: "POST",
        processData: false,
        contentType: "application/json",
        success: handleServerEvent,
        error: displayErrMsg,
        data: JSON.stringify({
            Username: document.getElementById('username').value,
            Password: document.getElementById('password').value
        })
    })

    document.getElementById('buttons').style.visibility = 'visible';
    document.getElementById('text-input').style.visibility = 'visible';
    document.getElementById('login-buttons').style.visibility = 'hidden';
    document.getElementById('login-info').style.visibility = 'hidden';
}
*/

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

function getData() {
    var tmpURL = serverAddr;
    var nameTxt = document.getElementById('name').value;
    if (nameTxt != "") { tmpURL += "/" + nameTxt; }
    $.ajax(tmpURL, {
        method: "GET",
        success: handleServerEvent,
        error: displayErrMsg
    });
}

function editPlayer() {
    $.ajax(serverAddr + "/" + document.getElementById('name').value, {
        method: "PATCH",
        contentType: "application/json",
        processData: false,
        success: handleServerEvent,
        error: displayErrMsg,
        headers: { 'if-match': ETag },
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
    var usernameTF = document.getElementById('username');
    var passwordTF = document.getElementById('password');
    clearTextField(nameTF);
    clearTextField(characterTF);
    clearTextField(weaponTF);
    clearTextField(gameTF);
    clearTextField(usernameTF);
    clearTextField(passwordTF);
}

function clearTextField(textField) {
    if (textField == "") { return; }
    textField.value = "";
}
