const elem = document.getElementById('panzoom-element')
const el_rect = elem.getBoundingClientRect();
const panzoom = Panzoom(elem, {
    minScale:1,
    maxScale: 2,
})
elem.parentElement.addEventListener('wheel', panzoom.zoomWithWheel)
