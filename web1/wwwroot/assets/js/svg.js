$(document).ready(function () {
    let svg = document.querySelector("#map-container svg");
    let temporary = document.getElementById("temporary");
    let svg_mapping = JSON.parse(temporary.text);
    temporary.remove();
    map_svg(svg, svg_mapping);
    $(document).on('click', '#map-dropdown .dropdown-menu', function (e) {
        e.stopPropagation();
    });
});

function map_svg(svg, svg_maping) {
    for (id in svg_maping) {
        let area = svg.getElementById(id);
        $(".map-button#"+id).click(function () {
            area.classList.toggle("hilighted");
            this.classList.toggle("active");
        });
        let title = area.querySelector("title");
        if (title == undefined) {
            title = document.createElementNS('http://www.w3.org/2000/svg', 'title');
            area.prepend(title);
        }
        title.textContent = svg_maping[id]["title"];
        area.classList.add("map-area");
        area.dataset.postid = svg_maping[id]["postid"];
        area.dataset.target = "#modal";
        area.dataset.toggle = "modal";
    }
}