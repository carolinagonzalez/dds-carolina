
function initMap(place, text) {
    var mapDiv = document.getElementById('map');
    var map = new google.maps.Map(mapDiv, {
        center: place,
        zoom: 18
    });

    var marker = new google.maps.Marker({
        position: place,
        title: text
    });

    marker.setMap(map);
}

$(document).ready(function () {

    $("input[name='palabraClave']").on("keyup", function () {
        if ($(this).val()) {
            $("button").addClass("call-to-action");
        } else {
            $("button").removeClass("call-to-action");
        }
    });

    
})