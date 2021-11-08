const elem = document.querySelector("#map-container svg");
const panzoom = Panzoom(elem, {
    minScale:1,
    maxScale: 2,
    contain:"outside"
})
elem.parentElement.addEventListener('wheel', panzoom.zoomWithWheel);
