﻿function init() {
    // gets current date and hours/minutes
    let date = new Date();
    let hour = addZero(date.getHours());
    let minute = addZero(date.getMinutes());

    //combines the time
    let combinedTime = `${hour}:${minute}`;

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

    //function returns am or pm
    let amPM = getAMPM(hours);

    //combines the minutes and numbers 
    let roundedTime = `${rHour}:${rMinute}${amPM}`;

    //returns the combination string
    return roundedTime;
}

function getAMPM(hour) {
    return (hour >= 12) ? "PM" : "AM";
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
    // takes in minute and date. if minute is 00 return current hour or an hour ahead
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

function startTimer() {
    //gets current date and time. sets the timeout to refresh the page every hour and half hour
    var now = new Date();
    var minutes = now.getMinutes();
    var seconds = now.getSeconds();
    setTimeout('refresh()', (((30 - (minutes % 30) - ((seconds > 0) ? 1 : 0)) * 60) + (60 - seconds)) * 1000);
}

function refresh() {
    //Reloads the page
    window.location.reload();
}

function setup() {
    init();
    startTimer();
}

//loads setup function on page load
Window.Onload = setup();