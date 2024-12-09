"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    document.getElementById("messagesList").appendChild(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you
    // should be aware of possible script injection concerns.
    li.textContent = `${user} says ${message}`;
});

connection.on("Conversation", function (senderId) {
    var messagesList = document.getElementById("messagesList");
    messagesList.innerHTML = ""; 
    messages.forEach(function (message) {
        var li = document.createElement("li");
        li.textContent = `${message.senderId} says ${message.content}`;
        messagesList.appendChild(li);
    });
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var entraineurId = document.getElementById("entraineur-object").getAttribute("entraineurId");
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", entraineurId, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});