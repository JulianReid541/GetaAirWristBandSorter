function init() {
    let date = new Date();
    let hour = addZero(date.getHours());
    let minute = addZero(date.getMinutes());

    let combinedTime = hour + ":" + minute;

    let roundedTime = RoundUp(combinedTime, date);

    document.getElementById(roundedTime).style.backgroundColor = "GoldenRod";
}

function RoundUp(time, date) {

    let [hours, minutes] = time.split(':');
    hours = parseInt(hours);
    minutes = parseInt(minutes);

    let rMinute = roundMinute(minutes);

    let rHour = roundHour(rMinute, date);

    let roundedTime = rHour + ":" + rMinute;

    return roundedTime;
}

function addZero(i) {
    if (i < 10) {
        i = "0" + i;
    }
    return i;
}

function roundMinute(m) {
    if (m < 30) {
        return 30;
    }
    else if (m >= 30) {
        return "00";
    }
}

function roundHour(m, date) {
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


Window.Onload = init();

setInterval(init, 1000);