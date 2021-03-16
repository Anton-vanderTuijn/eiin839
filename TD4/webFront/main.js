
var stations;

// ######################### Contracts #########################

function retrieveAllContracts() {
    var targetUrl = "https://api.jcdecaux.com/vls/v3/contracts?apiKey=" + document.getElementById("apiKey").value;
    var requestType = "GET";

    var caller = new XMLHttpRequest();
    caller.open(requestType, targetUrl, true);
    // The header set below limits the elements we are OK to retrieve from the server.
    caller.setRequestHeader ("Accept", "application/json");
    // onload shall contain the function that will be called when the call is finished.
    caller.onload=contractsRetrieved;

    caller.send();
}

function contractsRetrieved() {
    // Let's parse the response:
    var response = JSON.parse(this.responseText);

    var options = '';

    for (var i = 0; i < response.length; i++) {
        options += '<option value="' + response[i].name + '" />';
    }

    document.getElementById('contracts').innerHTML = options;
}

// ######################### Stations #########################

function retrieveContractStations() {
    if (document.getElementById("contract_choise").value !== "" && document.getElementById("apiKey").value !== "") {
        var targetUrl = "https://api.jcdecaux.com/vls/v3/stations?contract=" + document.getElementById("contract_choise").value + "&apiKey=" + document.getElementById("apiKey").value
        var requestType = "GET";

        var caller = new XMLHttpRequest();
        caller.open(requestType, targetUrl, true);
        // The header set below limits the elements we are OK to retrieve from the server.
        caller.setRequestHeader("Accept", "application/json");
        // onload shall contain the function that will be called when the call is finished.
        caller.onload = stationsRetrieved;

        caller.send();
    } else {
        console.log("contract or apikey field empty");
    }
}

function stationsRetrieved() {
    // Let's parse the response:
    stations = JSON.parse(this.responseText);
    console.log(stations);
}

// ######################### Nearest Stations #########################

function getClosestStation () {
    var userLat = document.getElementById("lat").value
    var userLng = document.getElementById("lng").value

    if (userLat !== "" && userLng !== "") {
        var neareststation;
        var nearestdistance = Number.MAX_VALUE;

        if (stations !== undefined) {
            for (var i = 0; i < stations.length; i++) {
                var distance = getDistanceFrom2GpsCoordinates(userLat, userLng, stations[i].position.latitude, stations[i].position.longitude);
                if (distance < nearestdistance) {
                    neareststation = stations[i];
                    nearestdistance = distance;
                }
            }
            console.log(neareststation);
            document.getElementById('closestStation').innerHTML = "Closest Station found : " + neareststation.name;
        } else {
            document.getElementById('closestStation').innerHTML = "No stations retrieved ! choose a contract and retrive stations";
        }
    } else {
        document.getElementById('closestStation').innerHTML = "Latitude or longitude undefined or invalid";
    }
}

function getDistanceFrom2GpsCoordinates(lat1, lon1, lat2, lon2) {
    // Radius of the earth in km
    var earthRadius = 6371;
    var dLat = deg2rad(lat2 - lat1);
    var dLon = deg2rad(lon2 - lon1);
    var a =
        Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) *
        Math.sin(dLon / 2) * Math.sin(dLon / 2)
        ;
    var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    var d = earthRadius * c; // Distance in km
    return d;
}

function deg2rad(deg) {
    return deg * (Math.PI / 180)
}