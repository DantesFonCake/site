var _cache = {};

var modal = $("#modal");
var modal_content = $("#popup-content");
var default_modal = $("#popup-content .modal-body");
modal.on("hide.bs.modal", function () {
    $(this).find('.yt-block').each(function () {
        this.contentWindow.postMessage('{"event":"command","func":"pauseVideo","args":""}', '*');
    });
});
$(".map-popup-button").each(function () {
    var $this = $(this);
    $this.click(function () {
        var id = $this.data("postid");
        if (!(id in _cache)) {

            var request = $.get("serialized/" + id)
                .done(function (data) {
                    _cache[id] = data;
                    repopulateModal(data);
                })
                .fail(function (req, status) {
                    console.log("Error: " + status);
                });
            modal_content.empty();
            modal_content.append(default_modal);
            modal_content.modal("handleUpdate");

        }
        else {
            repopulateModal(_cache[id]);
        }
    });
});

function repopulateModal(data) {
    modal_content.empty();
    modal_content.append(data);
    modal_content.modal("handleUpdate");
}