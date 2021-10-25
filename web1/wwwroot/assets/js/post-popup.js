var modal=$("#popup-modal")
$(".map-popup-button").each(function () {
    var $this = $(this);
    $this.click(function () {
        var request=$.get("serialized/" + $this.data("postid"))
            .done(function (data)
            {
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
    });
});