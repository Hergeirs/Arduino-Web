var chart;

function CreateChart(dachart, datas) {
    chart = new Chart(dachart,
        {
            type: 'line',
            data: {
                labels: datas.dataIds,
                datasets: [
                    {
                        data: datas.moistures,
                        label: "Moisture",
                        borderColor: "#3e95cd",
                        fill: false
                    }, {
                        data: datas.temperatures,
                        label: "Temperature",
                        borderColor: "#fa8072",
                        fill: false
                    }, {
                        data: datas.lights,
                        label: "Light",
                        borderColor: "#f1ec2e",
                        fill: false
                    }, {
                        data: datas.waters,
                        label: "Water",
                        borderColor: "#00ddd5",
                        fill: false
                    }
                ]
            }
        });
}

function AddToChart(canvas,arduinoData) {
    chart.data.labels.shift()
    chart.data.labels.push(arduinoData.dataId);
    chart.data.datasets.forEach(set => {
        const data = arduinoData[set.label.toLowerCase()];
        if(data!=null) {
            set.data.shift();
            set.data.push(data);
        }
    });
    chart.update();
}
