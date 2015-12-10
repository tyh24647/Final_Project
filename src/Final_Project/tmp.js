
//   >>>>>>>>>> DELETE ME <<<<<<<<<<<   //

var url = "http://localhost:61971/api/StarWars";
var etag = "";



function getCharacter() {
    var characterName = document.getElementById('characterName').value;
    if (characterName != "") {
        $.ajax(url + "/" + characterName, {
            method: "GET",
            success: displayPatchCharacters,
            error: displayErrorCode
        }
		);
    }
    else {
        $.ajax(url, {
            method: "GET",
            success: displayCharacters,
            error: displayErrorCode
        });
    }
}

function postCharacter() {
    var characterName = document.getElementById('characterName').value;
    var moviesPresent = document.getElementById('moviesPresent').value;
    var goodOrEvil = document.getElementById('goodOrEvil').value;
    var quote = document.getElementById('quote').value;
    var weapon = document.getElementById('weapon').value;

    $.ajax(url, {
        method: "POST",
        success: displayCharacters,
        error: displayErrorCode,
        contentType: 'application/json',
        data: JSON.stringify({
            CharacterName: characterName,
            MoviesPresent: moviesPresent,
            GoodOrEvil: goodOrEvil,
            Quote: quote,
            Weapon: weapon
        })
    }
	);

}

function patchCharacter() {
    var characterName = document.getElementById('characterName').value;
    var moviesPresent = document.getElementById('moviesPresent').value;
    var goodOrEvil = document.getElementById('goodOrEvil').value;
    var quote = document.getElementById('quote').value;
    var weapon = document.getElementById('weapon').value;

    $.ajax(url + "/" + characterName, {
        method: "PATCH",
        success: displayCharacters,
        error: displayErrorCode,
        contentType: 'application/json',
        headers: { 'if-match': etag },
        data: JSON.stringify({
            CharacterName: characterName,
            MoviesPresent: moviesPresent,
            GoodOrEvil: goodOrEvil,
            Quote: quote,
            Weapon: weapon
        })
    }
	);
}

//http://localhost:61971/api/
//This is where the login is happening
function PushFunc() {
    $.ajax("http://localhost:61971/api/Login", {
        //$.ajax(mainUrl + "login", {
        method: "POST",
        processData: false,
        contentType: "application/json",
        success: simpleResponse,
        data: JSON.stringify({
            username: document.getElementById('name').value,
            password: document.getElementById('password').value
        })
    });
}


function simpleResponse(data, data2, data3) {
    //document.getElementById('result').textContent = JSON.parse(data).Message;
    document.getElementById('result').innerHTML = JSON.stringify(data);
}





function clearTextBoxes() {
    //clear the text boxes
    document.getElementById('characterName').value = "";
    document.getElementById('moviesPresent').value = "";
    document.getElementById('goodOrEvil').value = "";
    document.getElementById('quote').value = "";
    document.getElementById('weapon').value = "";
}

function displayCharacters(data) {
    //clear the text boxes
    document.getElementById('characterName').value = "";
    document.getElementById('moviesPresent').value = "";
    document.getElementById('goodOrEvil').value = "";
    document.getElementById('quote').value = "";
    document.getElementById('weapon').value = "";


    document.getElementById('result').innerHTML = "";
    br();
    document.getElementById('result').appendChild(document.createTextNode(JSON.stringify(data)));
}

function displayPatchCharacters(data, textStatus, XMLHttpRequest) {
    document.getElementById('result').innerHTML = "";
    br();
    document.getElementById('result').appendChild(document.createTextNode("ETag: "));
    document.getElementById('result').appendChild(document.createTextNode(XMLHttpRequest.getResponseHeader('ETag')));
    br();
    br();
    document.getElementById('result').appendChild(document.createTextNode(JSON.stringify(data)));
    etag = XMLHttpRequest.getResponseHeader('ETag');
}

function displayErrorCode(data) {
    document.getElementById('result').innerHTML = ""
    br();
    document.getElementById('result').appendChild(document.createTextNode('Error Code: '));
    document.getElementById('result').appendChild(document.createTextNode(data['status'] + ' '));
    document.getElementById('result').appendChild(document.createTextNode(data['statusText']));
    br();
    br();
    document.getElementById('result').appendChild(document.createTextNode('Full Text: '));
    br();
    document.getElementById('result').appendChild(document.createTextNode(JSON.stringify(data)));
}

function br() {
    document.getElementById('result').appendChild(document.createElement('br'));
}
