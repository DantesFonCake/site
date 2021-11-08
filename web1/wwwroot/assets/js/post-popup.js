let _c = {};
$(document).ready(function () {
    let m = $("#modal");
    let mc = $("#popup-content");
    let dm = $("#popup-content .modal-body");
    m.on("hide.bs.modal", function () {
        $(this).find('.yt-block').each(function () {
            this.contentWindow.postMessage('{"event":"command","func":"pauseVideo","args":""}', '*');
        });
    });
    $(".map-area").each(function () {
        let $this = $(this);
        $this.click(function (e) {
            e.preventDefault();
            let i = $this.data("postid");
            if (!(i in _c)) {

                let request = $.get("serialized/" + i)
                    .done(function (data) {
                        _c[i] = data;
                        rM(data);
                    })
                    .fail(function (req, status) {
                        console.log("Error: " + status);
                    });
                rM(dm);
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
});