var dataString;

// Get the data from selected fields and begins drawing the chart.
function getData() {
    var classSelected = $('#ClassSelected').val();
    var dateSelected = $('#start').val();
    getChartData("CS", classSelected, dateSelected);
    buildChart(dataString, classSelected, dateSelected);
}

// Draws the chart.
function buildChart(dataString, classSelected, dateSelected) {
    
    Highcharts.chart('chart', {

        title: {
            text: 'Enrollment for: CS ' + classSelected
        },

        subtitle: {
            text: 'From: ' + dateSelected
        },

        yAxis: {
            title: {
                text: 'Number of students'
            }
        },

        xAxis: {
            type: 'datetime'
        },

        legend: {
            layout: 'vertical',
            align: 'right',
            verticalAlign: 'middle'
        },

        plotOptions: {
            series: {
                label: {
                    connectorAllowed: false
                },
                pointStart: Date.parse(dateSelected),
                pointInterval: 24 * 3600 * 1000
            }
        },

        series: [{
            name: 'CS' + classSelected,
            data: dataString
        }
        ],

        responsive: {
            rules: [{
                condition: {
                    maxWidth: 500
                },
                chartOptions: {
                    legend: {
                        layout: 'horizontal',
                        align: 'center',
                        verticalAlign: 'bottom'
                    }
                }
            }]
        }

    }); 
}




function getChartData(d, c, date) {
    $.ajax(
        {
            
            url: 'GetEnrollmentData',
            type: "POST",
            async: false,
            dataType: 'json',
            data: { dep: d, cNum: c, startDate: date},
            success: function (da, status, xhr) {
                dataString = da;
            }
        });
}

function getAvailableTimes() {
    $.ajax('Availabilities/GetSchedule',
        {
            dataType: 'json',
            async: false,
            success: function (data, status, xhr) {
                dataString = data;
            }
        });
}