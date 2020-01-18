// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var addCard = function () {

    var pin = document.getElementById("PIN").value;
    var name = document.getElementById("Name").value;
    var email = document.getElementById("Email").value;

    var url = "/Home/AddCard"

    var infoCard = new Object();
    infoCard.PIN = pin;
    infoCard.Name = name;
    infoCard.Email = email;

    fetch(url, {
        method: 'POST',
        cache: 'no-cache',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(infoCard)
    })
    .then((response) =>
    {
        if (response.ok) {
            response.json().then(json => {
                console.log(json);

                var cardContentElement = document.getElementById("cardContent");

                var node = document.createElement("p");
                node.innerText = "SomeElement";

                cardContentElement.appendChild(node);

            });
        }
    })
    .catch((error) => { console.error("Error: " + error); });
};
