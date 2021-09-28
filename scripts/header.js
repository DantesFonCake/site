$(function () {
    $(window).on('scroll', function () {
        if ( $(window).scrollTop() > 8 ) {
            $('.navbar').addClass('active');
        } else {
            $('.navbar').removeClass('active');
        }
    });
});