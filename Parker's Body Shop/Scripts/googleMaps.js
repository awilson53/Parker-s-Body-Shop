// Contains methods to initialize and load a google maps canvas.

function initialize() {
    var location = new google.maps.LatLng(35.1015, -81.2325);
    var mapCanvas = document.getElementById('map-canvas');
    var mapOptions = {
        center: location,
        zoom: 14,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    var map = new google.maps.Map(mapCanvas, mapOptions);
    var marker = new google.maps.Marker({
        position: location,
        map: map,
        title: 'Parker\'s Body Shop',
        animation: google.maps.Animation.DROP
    })

    loadMapWidget();
}

function loadMapWidget() {
    google.maps.event.addDomListener(window, 'load', initialize);
}