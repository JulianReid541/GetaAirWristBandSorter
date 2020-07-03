﻿function init() {
    // gets current date and hours/minutes
    let date = new Date();
    let hour = addZero(date.getHours());
    let minute = addZero(date.getMinutes());

    //combines the time
    let combinedTime = hour + ":" + minute;

    //gets rounded time from method
    let roundedTime = RoundUp(combinedTime, date);

    //updates background of the corresponding ID
    document.getElementById(roundedTime).style.background = "GoldenRod";
}

function RoundUp(time, date) {
    // gets incoming time and date. Splits it via the : 
    let [hours, minutes] = time.split(':');

    //parse the hours and minutes
    hours = parseInt(hours);
    minutes = parseInt(minutes);

    // rounds the minute to the nearest 00 or 30
    let rMinute = roundMinute(minutes);

    //rounds the hour if the time change is an hour change other wise the hour is the current hour
    let rHour = roundHour(rMinute, date);

    //combines the minutes and numbers 
    let roundedTime = rHour + ":" + rMinute;

    //returns the combination string
    return roundedTime;
}

function addZero(i) {
    //takes in coming number and returns a zero if needed
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}

function roundMinute(m) {
    // take in minute from date. If > then thirty minutes returns rounded time of 00 or 30
    if (m < 30 || m == 0) {
        return 30;
    }
    else if (m >= 30 && m <= 59) {
        return "00";
    }
}

function roundHour(m, date) {
    // takes in minute and date. if minute is 00 return current hour or and hour ahead
    if (m !== "00") {
        let hour = date.getHours();
        if (hour % 12 != 0)
            return (hour % 12);
        else
            return 12;
    }
    else {
        let hour = date.getHours() + 1;
        if (hour % 12 != 0)
            return (hour % 12);
        else
            return 12;
    }
}

//loads init function on page load
Window.Onload = new init();

//refreshes init every second 
setTimeout(function () {
    //window.location.reload()
    new init();
}, 1000);