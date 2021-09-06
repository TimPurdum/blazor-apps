export function InitializeChart (config)  {
    if (myChart !== undefined && myChart !== null) {
        myChart.destroy();
    }
    myChart = new Chart(
        document.getElementById('chart-canvas'),
        config);
}

const labels = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
];
const data = {
    labels: labels,
    datasets: [{
        label: 'My First dataset',
        backgroundColor: 'rgb(255, 99, 132)',
        borderColor: 'rgb(255, 99, 132)',
        data: [0, 10, 5, 2, 20, 30, 45],
    }]
};

const testConfig = {
    type: 'line',
    data,
    options: {}
};

let myChart;