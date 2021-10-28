$('.map-image').maphilight();
$('.map-switch').click(function (e) {
    var c = "." + String(this.value);
    var a = $('#map').find(c);
    var data = a.mouseout().data('maphilight') || {};
    data.alwaysOn = !data.alwaysOn;
    data.neverOn = !data.neverOn;
    a.data('maphilight', data).trigger('alwaysOn.maphilight');
    a.data('maphilight', data).trigger('neverOn.maphilight');
});