/* Theme Name: Ipsa | Responsive Bootstrap Template
   Author: Themesdesign
   Version: 1.0.0
   File Description: Main JS file of the template
*/


! function($) {
    "use strict";

    var Ipsa = function() {};

    Ipsa.prototype.initStickyMenu = function() {
        // Add scroll class
        $(window).scroll(function() {
            var scroll = $(window).scrollTop();

            if (scroll >= 50) {
                $(".sticky").addClass("nav-sticky");
            } else {
                $(".sticky").removeClass("nav-sticky");
            }
        });
    },

    Ipsa.prototype.initSmoothLink = function() {
        // Smooth scroll
        $('.btn-custom').on('click', function(event) {
            var $anchor = $(this);
            $('html, body').stop().animate({
                scrollTop: $($anchor.attr('href')).offset().top - 0
            }, 500, 'easeInOutExpo');
            event.preventDefault();
        });
    },

    Ipsa.prototype.initTestimonials = function() {
        //Owl Carousel
        $("#owl-demo").owlCarousel({
            autoPlay: 3000,
            stopOnHover: true,
            navigation: false,
            paginationSpeed: 1000,
            goToFirstSpeed: 2000,
            singleItem: true,
            autoHeight: true,
        });
    },

    Ipsa.prototype.initScrollspy = function() {
        //Scrollspy
        $(".navbar-nav").scrollspy({
            offset: 50
        });
    },

    Ipsa.prototype.initPortfolioFilter = function() {
        // Portfolio filter
        $(window).on('load', function () {
            var $container = $('.projects-wrapper');
            var $filter = $('#filter');
            // Initialize isotope
            $container.isotope({
                filter: '*',
                layoutMode: 'masonry',
                animationOptions: {
                    duration: 750,
                    easing: 'linear'
                }
            });

            // Filter items when filter link is clicked
            $filter.find('a').on("click",function() {
                var selector = $(this).attr('data-filter');
                $filter.find('a').removeClass('active');
                $(this).addClass('active');
                $container.isotope({
                    filter: selector,
                    animationOptions: {
                        animationDuration: 750,
                        easing: 'linear',
                        queue: false,
                    }
                });
                return false;
            });
        });
    },

    Ipsa.prototype.initMagnificPopup = function() {
        // Magnific Popup
        $('.mfp-image').magnificPopup({
            type: 'image',
            closeOnContentClick: true,
            mainClass: 'mfp-fade',
            gallery: {
                enabled: true,
                navigateByImgClick: true,
                preload: [0, 1]
            }
        });
    },

    Ipsa.prototype.initContact = function() {
        //Contact Form
        $('#contact-form').submit(function() {

            var action = $(this).attr('action');

            $("#message").slideUp(750, function() {
                $('#message').hide();

                $('#submit')
                    .before('')
                    .attr('disabled', 'disabled');

                $.post(action, {
                        name: $('#name').val(),
                        email: $('#email').val(),
                        comments: $('#comments').val(),
                    },
                    function(data) {
                        document.getElementById('message').innerHTML = data;
                        $('#message').slideDown('slow');
                        $('#cform img.contact-loader').fadeOut('slow', function() {
                            $(this).remove()
                        });
                        $('#submit').removeAttr('disabled');
                        if (data.match('success') != null) $('#cform').slideUp('slow');
                    }
                );

            });

            return false;

        });
    },

     Ipsa.prototype.init = function() {
        this.initStickyMenu();
        this.initSmoothLink();
        this.initTestimonials();
        this.initScrollspy();
        this.initPortfolioFilter();
        this.initMagnificPopup();
        this.initContact();
    },
    //init
    $.Ipsa = new Ipsa, $.Ipsa.Constructor = Ipsa
}(window.jQuery),

//initializing
function($) {
    "use strict";
    $.Ipsa.init();
}(window.jQuery);
