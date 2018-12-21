"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("/dataHub").build();

connection.on("UpdateData", function (data) {
    console.log(data);
    const plantDiv = document.getElementById(data.PlantId);
    plantDiv.getElementsByClassName("temperature")[0]
        .getElementsByClassName("value")[0]
        .textContent = data.Temperature;

    plantDiv.getElementsByClassName("moisture")[0]
        .getElementsByClassName("value")[0]
        .textContent = data.Moisture;

    plantDiv.getElementsByClassName("light")[0]
        .getElementsByClassName("value")[0]
        .textContent = data.Light;

    plantDiv.getElementsByClassName("water")[0]
        .getElementsByClassName("value")[0]
        .textContent = data.Water;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});
