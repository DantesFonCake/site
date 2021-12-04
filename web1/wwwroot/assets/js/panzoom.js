$(document).ready(function () {
    let elem = document.querySelector("#map-container svg");
    elem.classList.add("no-pan");
    let panzoom = Panzoom(elem, {
        minScale: 1,
        maxScale: 2,
        contain: "outside",
        disablePan: true
    });
    let zoomin = document.getElementById("map-plus");
    let zoomout = document.getElementById("map-minus");
    let zoomrange = document.getElementById("map-zoom");
    let zoomoptions = { step: 0.2 };
    let enablepan = document.getElementById("map-pan");
    zoomin.addEventListener('click', function () {
        panzoom.zoomIn(zoomoptions);
        zoomrange.value = panzoom.getScale();
    });
    zoomout.addEventListener('click', function () {
        panzoom.zoomOut(zoomoptions);
        zoomrange.value = panzoom.getScale();
    });
    zoomout.addEventListener('panzoomzoom', function () {
        zoomrange.value = panzoom.getScale();
    });
    zoomrange.addEventListener('input', (event) => {
        panzoom.zoom(event.target.valueAsNumber)
    });
    enablepan.addEventListener('click', function () {
        enablepan.classList.toggle("active");
        let pan = enablepan.classList.contains("active");
        panzoom.setOptions({ disablePan: !pan });
        if (!pan)
            elem.classList.add("no-pan");
        else
            elem.classList.remove("no-pan");
    });
});
