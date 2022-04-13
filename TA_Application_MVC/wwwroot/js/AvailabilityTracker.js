// Text Styles
const dayStyle = new PIXI.TextStyle({
    fontSize: 20,
});
const saveTimeStyle = new PIXI.TextStyle({
    fontSize: 14,
    fill: "#00661a",

});
const timeStyle = new PIXI.TextStyle({
    fontSize: 12,
});

/************************************
 * Program Logic
 ************************************/

// Get data from controller through get request
var dataString;
getAvailableTimes();

// Take the unId from the data
// remove the unid from rest of array
let unid = dataString[0];
let dateString = dataString.splice(0, 1);

// Build an array to mark available times
const AlreadyAvailableDays = new Array(5);
FindCurrentAvailability();

// Create the stage.
let app = new PIXI.Application({
    width: 850,
    height: 850,
    antialias: true,
    backgroundColor: 0xa6a6a6
});
document.body.appendChild(app.view);

BuildAvailabilityTracker();

// Place Timestamp
var timestamp = new PIXI.Text("Last Saved:", saveTimeStyle);
timestamp.x = 150 * 4 + 50;
timestamp.y = 50;
app.stage.addChild(timestamp);


/************************************
 * Helper Functions Logic
 ************************************/

/**
 * Makes a GET request and fills dataString with unID and availability.
 */
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

/**
 * Parses the availability strings to build an array that corresponds
 * with the day that are available.
 */
function FindCurrentAvailability() {
    // Build the empty array
    // 5 days in a week
    // 12 hours is 48 25 minute intervals
    for (var i = 0; i < AlreadyAvailableDays.length; i++) {
        AlreadyAvailableDays[i] = new Array(48);
        for (var j = 0; j < AlreadyAvailableDays[i].length; j++) {
            AlreadyAvailableDays[i][j] = false; // by default all days are false.
        }
    }

    // Convert timeslot string into its numberical values so it corresponces
    // one to one with the pixi array.
    for (var i = 0; i < dataString.length; i++) {
        parseString = dataString[i].split(' ');
        availableTime = ((parseString[1] - 8) / .25);   // Cell number
        availableDays = (DayToNumber(parseString[0])); // Day of the Cell

        AlreadyAvailableDays[availableDays][availableTime] = true;
    }
}

/**
 * Builds the availablity tracker
 */
function BuildAvailabilityTracker() 
{
    const week = new Array(5);
    for (var i = 0; i < week.length; i++) {
        // get Day
        var day = new PIXI.Text(`${NumberToDay(i)}`, dayStyle);
        day.x = 150 * i + 50;
        day.y = 75;
        app.stage.addChild(day);

        week[i] = new Array(48);
        for (var j = 0; j < week[i].length; j++) {
            if (AlreadyAvailableDays[i][j]) {
                week[i][j] = new Rectangle(i, j, true);
            }
            else {
                week[i][j] = new Rectangle(i, j, false);
            }
            app.stage.addChild(week[i][j]);
        }

        // Add times and lines
        if (i === (week.length - 1)) {         
            for (var k = 0; k < 13; k++) {
                var time = new PIXI.Text(`${k + 8}:00`, timeStyle);
                time.x = 155 * 5;
                time.y = 15 * (k * 4) + 95;
                app.stage.addChild(time);

                var l = new Line(time.x, time.y + 5);
                app.stage.addChild(l);
            }
        }
    }
}

/**
 * Sends a post request to update the database each time a rectangle is clicked.
 */
function updateDB(available, day, hour)
{
    $.ajax(
    {
        url: "Availabilities/SetSchedule",
        type: "POST",
        async: true,
        data: { availability: available, Day: NumberToDay(day), Hour: (8 + (hour * .25)), unId: unid },
            success: function () {
            // Update Timestamp
            var d = new Date();
            var n = d.toLocaleTimeString();
            timestamp.text = `Last Saved: ${n}`;           
        }           
    });
}

/**
 * Converts a number to its day string value
 */
function NumberToDay(num) {
    var day;
    // Source https://www.w3schools.com/js/js_switch.asp
    switch (num) {

        case 0:
            day = "Monday";
            break;
        case 1:
            day = "Tuesday";
            break;
        case 2:
            day = "Wednesday";
            break;
        case 3:
            day = "Thursday";
            break;
        case 4:
            day = "Friday";
            break;
    }
    return day;
}

/**
 * Converts a string day into its number value.
 */
function DayToNumber(day) {
    var num;
    // Source https://www.w3schools.com/js/js_switch.asp
    switch (day) {

        case "Monday":
            num = 0;
            break;
        case "Tuesday":
            num = 1;
            break;
        case "Wednesday":
            num = 2;
            break;
        case "Thursday":
            num = 3;
            break;
        case "Friday":
            num = 4;
            break;
    }
    return num;
}
