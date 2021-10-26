var modal = $("#popup-modal");
var default_modal = $("#default-modal");
console.log(default_modal);
$(".map-popup-button").each(function () {
    var $this = $(this);
    $this.click(function () {
        var request=$.get("serialized/" + $this.data("postid"))
            .done(function (data)
            {
                default_modal.modal('hide');
                $(".modal-backdrop").remove();
                modal.empty();
                modal.append(data);
                var m = modal.children(".modal");
                m.modal();
                m.modal('show');
            })
            .fail(function (req,status)
            {
                console.log("Error: " + status);
            });
        modal.empty();
        modal.append(default_modal);
        default_modal.modal();
        default_modal.modal('show');
    });
});