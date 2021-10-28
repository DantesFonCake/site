var _c = {};

var m = $("#modal");
var mc = $("#popup-content");
var dm = $("#popup-content .modal-body");
m.on("hide.bs.modal", function () {
    $(this).find('.yt-block').each(function () {
        this.contentWindow.postMessage('{"event":"command","func":"pauseVideo","args":""}', '*');
    });
});
$(".map-popup-button").each(function () {
    var $this = $(this);
    $this.click(function (e) {
        //e.preventDefault();
        var i = $this.data("postid");
        if (!(i in _c)) {

            var request = $.get("serialized/" + i)
                .done(function (data) {
                    _c[i] = data;
                    rM(data);
                })
                .fail(function (req, status) {
                    console.log("Error: " + status);
                });
            mc.empty();
            mc.append(dm);
            mc.modal("handleUpdate");
        }
        else {
            rM(_c[i]);
        }
        //mc.modal('show');
    });
});

function rM(data) {
    mc.empty();
    mc.append(data);
    mc.modal("handleUpdate");
}