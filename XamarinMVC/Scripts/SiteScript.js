///gallery

var slideIndex = 1;
showSlides(slideIndex);
function plusSlides(n) {
    showSlides(slideIndex += n);
}
function currentSlides(n) {
    showSlides(slideIndex = n);
}
function showSlides() {
    var i;
    var slides = document.getElementsByClassName("mySlides");
    var dots = document.getElementsByClassName("demo");
    if (n > slides.length) { slideIndex = 1; }
    if (n < 1) { slideIndex = slides.length; }
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}




//Navbar Scripts
window.onscroll = function () { myfunction() };

var navbar = document.getElementById("navbar");
var sticky = navbar.offsetTop;

function myfunction() {
    if (window.pageYOffset >= sticky) {
        navbar.classList.add("sticky");
    } else {
        navbar.classList.remove("sticky");
    }
}

/// Brand Slider Scripts

var count = 1,
    smallParent2 = $('.small2'),
    smallUlLi2 = $('.small2 .small-ul li'),
    smallSpan2 = $('.small2 .small-span'),
    sliderTime = 1000,
    smallSetLeft2,
    smallRunLeft2;

smallUlLi2.parent().attr('data-small2', smallUlLi2.length);

smallParent2.width(smallParent2.parent().width()).height(smallUlLi2.height());

smallUlLi2.parent().width(smallUlLi2.width() * (smallUlLi2.length + 1));

smallSetLeft2 = function () {
    var smallUlLi2 = $('.small2 .small-ul li');
    if (smallUlLi2.length <= smallUlLi2.parent().data('small2')) {
        smallUlLi2.parent().append('<li>' + smallUlLi2.first().html() + '</li>').children().first().animate({
            marginLeft: -smallUlLi2.first().outerWidth()
        }, sliderTime, function () {
            smallUlLi2.first().remove();
        });
    }
};

smallRunLeft2 = setInterval(smallSetLeft2, sliderTime * 3);

smallSpan2.mouseenter(function () {
    clearInterval(smallRunLeft2);
});

smallSpan2.mouseleave(function () {
    smallRunLeft2 = setInterval(smallSetLeft2, sliderTime * 3);
});

smallSpan2.first().on('click', function () {
    var smallUlLi2 = $('.small2 .small-ul li'),
        smallLastLi2 = smallUlLi2.last().html();
    if (smallUlLi2.length <= smallUlLi2.parent().data('small2')) {
        smallUlLi2.parent().prepend('<li>' + smallUlLi2.last().html() + '</li>').children().last();
        smallUlLi2.first().prev().css('width', 4);
        smallUlLi2.first().prev().animate({
            width: smallUlLi2.first().outerWidth()
        }, sliderTime / 5, function () {
            smallUlLi2.last().remove();
        });
    }
});

smallSpan2.last().on('click', function () {
    var smallUlLi2 = $('.small2 .small-ul li'),
        smallFirstLi2 = smallUlLi2.first().html();
    if (smallUlLi2.length <= smallUlLi2.parent().data('small2')) {
        smallUlLi2.parent().append('<li>' + smallUlLi2.first().html() + '</li>').children().first().animate({
            marginLeft: -smallUlLi2.first().outerWidth()
        }, sliderTime, function () {
            smallUlLi2.first().remove();
        });
    }
});