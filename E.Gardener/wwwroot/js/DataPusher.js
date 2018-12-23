const connection = new signalR.HubConnectionBuilder().withUrl("/dataHub").build();

connection.on("UpdateData", function (data) {
    console.log(data);
    const plantDiv = document.getElementById(data.plantId);

    plantDiv.getElementsByClassName("id")[0]
        .getElementsByClassName("value")[0]
        .textContent = data.dataId;
 
    plantDiv.getElementsByClassName("temperature")[0]
        .getElementsByClassName("value")[0]
        .textContent = data.temperature;

    plantDiv.getElementsByClassName("moisture")[0]
        .getElementsByClassName("value")[0]
        .textContent = data.moisture;

    plantDiv.getElementsByClassName("light")[0]
        .getElementsByClassName("value")[0]
        .textContent = data.light;

    plantDiv.getElementsByClassName("water")[0]
        .getElementsByClassName("value")[0]
        .textContent = data.water;
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});
