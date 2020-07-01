function init() {
    let date = new Date();
    let hour = addZero(date.getHours());
    let minute = addZero(date.getMinutes());

    let combinedTime = hour + ":" + minute;

    let roundedTime = RoundUp(combinedTime);

    document.getElementById(roundedTime).style.backgroundColor = "GoldenRod";
}

function RoundUp(time) {

    let [hours, minutes] = time.split(':');
    hours = parseInt(hours);
    minutes = parseInt(minutes);

    let rMinute = roundMinute(minutes);

    let rHour = roundHour(hours, rMinute);

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
    if (m <= 30) {
        return 30;
    }
    else if (m > 30) {
        return 0;
    }
}

function roundHour(h, m) {
    const d = new Date();
    if (m != 0) {
        return addZero(d.getHours());
    }
    else {
        return addZero(d.getHours + 1);
    }
}


Window.Onload = init();

setInterval(init, 1000);