$(window).scroll(function () {

    var menu = document.getElementById("menu");
    var sticky = menu.offsetTop;

    if (window.pageYOffset > sticky) {
        menu.classList.add("sticky");
    } else {
        menu.classList.remove("sticky");
    }

    //if ($(window).scrollTop() >= 100) {
    //    $('nav').addClass('fixed-header');
    //    $('nav div').addClass('visible-title');
    //}
    //else {
    //    $('nav').removeClass('fixed-header');
    //    $('nav div').removeClass('visible-title');
    //}
});


$('.up-to-top').click(function () {
    $("html, body").animate({ scrollTop: 0 }, 200);
})