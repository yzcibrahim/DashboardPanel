
function CreateLineChart(labels, dataArr, legend, elementId) {
    const data = {
        labels: labels,
        datasets: [{
            label: legend,
            backgroundColor: 'rgb(255, 99, 132)',
            borderColor: 'rgb(255, 99, 132)',
            data: dataArr,
        }]
    };
    const config = {
        type: 'line',
        data: data,
        options: {
            responsive: true,
            maintainAspectRatio: false}
    };
    const myChart = new Chart($('#' + elementId), config);
    myChart.resize();
}

function CreateBarChart(labels, dataArr, legend, elementId,colors) {
    const data = {
        labels: labels,
        datasets: [{
            label: legend,
            backgroundColor: colors,
            borderColor: colors,
            data: dataArr,
        }]
    };
    const config = {
        type: 'bar',
        data: data,
        options: {
            responsive: true,
            maintainAspectRatio: false}
    };
    const myChart = new Chart($('#' + elementId), config);
    myChart.resize();
}

function CreatePieChart(labels, dataArr, legend, elementId, colors) {
    const data = {
        labels: labels,
        datasets: [{
            label: legend,
            backgroundColor: colors,
            borderColor: colors,
            data: dataArr,
        }]
    };
    const config = {
        type: 'pie',
        data: data,
        options: {
            plugins: {
                legend: {
                    position: 'bottom',
                },
                responsive: true,
                maintainAspectRatio: false
            }
        }
    };
    const myChart = new Chart($('#' + elementId), config);
    myChart.resize();
}

