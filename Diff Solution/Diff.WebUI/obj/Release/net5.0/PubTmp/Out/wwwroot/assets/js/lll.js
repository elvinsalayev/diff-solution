jQuery(document).ready(function ($) {
    (function ($) {
        "use strict";
        Global_Scripts();
        Header_Scripts();
        HeroSlide_Scripts();
        Slide_Scripts();
        CardsAni_Scripts();
        portfolio_Scripts();
        Splitting({ target: ".preloader .logo-text h6", by: "chars" });
        var preloaderLogoText = $(".preloader .logo-text");
        var preloaderHedingText = $(".preloader .logo-text h6 .char");
        var preloaderPText = $(".preloader .logo-text p span");
        var preloaderLine = $(".preloader .logo-text .line");
        TweenMax.set(preloaderLogoText, { autoAlpha: 1 });
        var PreTl = new TimelineMax({ repeat: -1 });
        PreTl.to(preloaderLine, 1, { x: "0%", ease: Expo.easeInOut })
            .staggerTo(preloaderHedingText, 1, { y: "0%", ease: Expo.easeOut }, 0.05, "-=0.4")
            .to(preloaderPText, 1, { y: "-0%", ease: Expo.easeOut }, "-=0.4")
            .staggerTo(preloaderHedingText, 1, { y: "-100%", ease: Expo.easeOut }, 0.05, "-=0.4")
            .to(preloaderLine, 1, { x: "100%", ease: Expo.easeInOut }, "-=0.8");
        $(window).on("load", function () {
            PreTl.pause();
            TweenMax.to(preloaderLogoText, 0.5, { y: -50, autoAlpha: 0, ease: Power3.easeInOut });
            var Preloader = $(".preloader");
            var PreloaderBGSpan = $(".preloader-bg span");
            var PreloaderBG = $(".preloader-bg");
            var PreloaderOutTl = new TimelineMax();
            PreloaderOutTl.staggerTo(PreloaderBGSpan, 1, { y: "0%", ease: Expo.easeOut }, 0.15)
                .set(PreloaderBG, { background: "transparent" })
                .staggerTo(PreloaderBGSpan, 1, { y: "-100%", ease: Expo.easeOut }, 0.15)
                .set(Preloader, { display: "none" });
            TextAni_Scripts();
        });
    })(jQuery);
    function Global_Scripts() {
        function ProjectGrid() {
            $(".project-list-area").isotope({ itemSelector: ".project-grid", masonry: { columnWidth: ".project-grid" } });
        }
        ProjectGrid();
        setInterval(ProjectGrid, 3000);
        $("[data-img-src]").each(function () {
            var Src = $(this).data("img-src");
            $(this).css("background-image", "url(" + Src + ")");
        });
        Splitting({ target: ".has-word", by: "chars" });
       
        jarallax(document.querySelectorAll(".parallax-bg"), { speed: 0.7 });
        jarallax(document.querySelectorAll(".page-top-section .page-top-bg"), { speed: 0.8 });
        var ctrlSM = new ScrollMagic.Controller();
        $(".scroll-back-to-top").on("click", function () {
            $("html, body").animate({ scrollTop: 0 }, 1000, "easeInOutExpo");
        });
        $(".lity-videopopup").on("click", lity);
        $(".page-top-section").each(function () {
            var ShapeLeft = $(this).find(".shape-left");
            var TopImg = $(this).find(".top-img");
            $(this).mousemove(function (e) {
                var decimalX = e.clientX / window.innerWidth - 1.2;
                var decimalY = e.clientY / window.innerHeight - 1.2;
                TweenMax.to(ShapeLeft, 1, { x: 10 * -decimalX, y: 10 * decimalY, ease: Quad.easeOut });
                TweenMax.to(TopImg, 0.5, { x: 10 * decimalX, ease: Quad.easeOut, transformPerspective: 700, transformOrigin: "center" });
            });
        });
        $(".m-parallax-wrap").each(function () {
            var paraqllax_el = $(this).find(".mrot-parallax-el");
            $(this).mousemove(function (e) {
                var decimalX = e.clientX / window.innerWidth - 0.5;
                var decimalY = e.clientY / window.innerHeight - 0.5;
                TweenMax.to(paraqllax_el, 0.5, { rotationY: 10 * decimalX, rotationX: 10 * decimalY, ease: Quad.easeOut, transformPerspective: 700, transformOrigin: "center" });
            });
        });
    }
    function Header_Scripts() {
        $(window).on("scroll", HeaderSticky);
        function HeaderSticky() {
            var ScrollTop = $(window).scrollTop();
            if (ScrollTop > 50) {
                $(".header-area").addClass("sticky");
            } else {
                $(".header-area").removeClass("sticky");
            }
        }
        HeaderSticky();
        $(".full-scree-navbar").each(function () {
            $(this).find(".dropdown").addClass("dropdown-nav");
            $(this).find(".dropdown-menu").addClass("submenu");
        });
        $(".full-scree-navbar .dropdown-nav .nav-link").on("click", function (j) {
            var dropDown = $(this).closest(".dropdown-nav").find(".dropdown-menu");
            $(this).closest(".full-scree-navbar").find(".dropdown-menu").not(dropDown).slideUp();
            if ($(this).hasClass("active")) {
                $(this).removeClass("active");
            } else {
                $(this).closest(".accordion").find("a.active").removeClass("active");
                $(this).addClass("active");
            }
            dropDown.stop(false, true).slideToggle();
            j.preventDefault();
        });
        let NavTl = new TimelineMax({ paused: true });
        let NavArea = $(".full-screen-nav");
        let NavAreaBG = $(".full-screen-nav .flsbg .bg-wrap");
        let NavAreaBGSpan = $(".full-screen-nav .flsbg .bg-wrap span");
        let NavOverlay = $(".full-screen-nav .nav-overlay");
        let NavContact = $(".full-screen-nav .nav-contact-list .citem");
        let NavItem = $(".full-scree-navbar .nav-item");
        let NavLink = $(".full-scree-navbar .nav-item .nav-link");
        TweenMax.set(NavArea, { background: "transparent" });
        TweenMax.set(NavItem, { rotationX: 20, y: 40, autoAlpha: 0 });
        TweenMax.set(NavContact, { rotationX: 20, rotation: 2, y: 70, autoAlpha: 0 });
        NavTl.set(NavArea, { display: "block" })
            .staggerTo(NavAreaBG, 0.6, { y: "0%", ease: Expo.easeInOut }, 0.05)
            .staggerTo(NavAreaBGSpan, 0.6, { x: "102%", ease: Expo.easeInOut }, 0.08, "-=0.3")
            .set(NavArea, { background: "#fff" })
            .staggerTo(NavItem, 0.5, { rotationX: 0, rotation: 0, y: 0, autoAlpha: 1, ease: Power2.easeOut }, 0.06)
            .staggerTo(NavContact, 0.5, { rotationX: 0, rotation: 0, y: 0, autoAlpha: 1, ease: Power2.easeOut }, 0.02, "-=0.4");
        NavTl.reverse();
        $(".header-area .nav-toggle-btn").on("click", function () {
            $(".header-area .nav-toggle-btn").toggleClass("open");
            $(".header-area").toggleClass("open-fullnav");
            NavTl.reversed(!NavTl.reversed());
        });
    }
    function HeroSlide_Scripts() {
        $(".hero_slide_wrapper").each(function () {
            var SlideText = new Swiper(".hero_slide_wrapper .text_slide_container", {
                loop: true,
                speed: 1200,
                grabCursor: true,
                resistance: true,
                resistanceRatio: 0,
                watchSlidesProgress: true,
                mousewheelControl: true,
                keyboardControl: true,
                effect: "slide",
                mousewheel: false,
                parallax: true,
                navigation: { nextEl: ".hero_slide_wrapper .btn_next_arrow", prevEl: ".hero_slide_wrapper .btn_prev_arrow" },
            });
            var interleaveOffset = 0.4;
            var SlideBg = new Swiper(".hero_slide_wrapper .bg_slide_container", {
                loop: true,
                speed: 1200,
                grabCursor: true,
                watchSlidesProgress: true,
                mousewheelControl: true,
                keyboardControl: true,
                resistance: true,
                resistanceRatio: 0.5,
                on: {
                    progress: function () {
                        var swiper = this;
                        for (var i = 0; i < swiper.slides.length; i++) {
                            var slideProgress = swiper.slides[i].progress;
                            var innerOffset = swiper.width * interleaveOffset;
                            var innerTranslate = slideProgress * innerOffset;
                            swiper.slides[i].querySelector(".slide_bg").style.transform = "translate3d(" + innerTranslate + "px, 0, 0)";
                        }
                    },
                    touchStart: function () {
                        var swiper = this;
                        for (var i = 0; i < swiper.slides.length; i++) {
                            swiper.slides[i].style.transition = "";
                        }
                    },
                    setTransition: function (speed) {
                        var swiper = this;
                        for (var i = 0; i < swiper.slides.length; i++) {
                            swiper.slides[i].style.transition = speed + "ms";
                            swiper.slides[i].querySelector(".slide_bg").style.transition = speed + "ms";
                        }
                    },
                },
            });
            SlideText.controller.control = SlideBg;
            SlideBg.controller.control = SlideText;
        });
    }
    function Slide_Scripts() {
        new Swiper(".brand-slide-container", {
            loop: true,
            speed: 500,
            grabCursor: true,
            resistance: true,
            resistanceRatio: 0,
            watchSlidesProgress: true,
            mousewheelControl: true,
            keyboardControl: true,
            slidesPerView: 5,
            centeredSlides: false,
            breakpoints: { 300: { slidesPerView: 2, centeredSlides: true }, 640: { slidesPerView: 3, centeredSlides: true }, 991: { slidesPerView: 4 }, 1199: { slidesPerView: 5 } },
        });
        new Swiper(".service-slide-container", {
            loop: true,
            speed: 500,
            grabCursor: true,
            resistance: true,
            resistanceRatio: 0,
            watchSlidesProgress: true,
            mousewheelControl: true,
            keyboardControl: true,
            slidesPerView: 4,
            centeredSlides: false,
            breakpoints: {
                300: { slidesPerView: 1, centeredSlides: true, spaceBetween: 15 },
                767: { slidesPerView: 2, spaceBetween: 20, centeredSlides: true },
                767: { slidesPerView: 2, spaceBetween: 20, centeredSlides: true },
                1199: { slidesPerView: 3, spaceBetween: 25 },
                1200: { slidesPerView: 4, spaceBetween: 25 },
            },
        });
        new Swiper(".testimonial-slide-container", { loop: false, speed: 1000, grabCursor: true, watchSlidesProgress: true, mousewheelControl: true, keyboardControl: true, slidesPerView: 1, parallax: true });
    }
    function portfolio_Scripts() {
        $(".portfolio_card_wrapper").each(function () {
            var MainImage = $(this).find(".portfolio-card-thumb");
            $(this).append('<span class="portfolio-card_bg">');
            $(this)
                .find(".portfolio-card_bg")
                .css("background-image", "url(" + MainImage.attr("src") + ")");
        });
    }
    function TextAni_Scripts() {
        let SMctrl = new ScrollMagic.Controller();
        $(".has-sectitle-ani").each(function () {
            Splitting({ target: ".has-sectitle-ani .sub-title", by: "lines" });
            Splitting({ target: ".has-sectitle-ani .title", by: "lines" });
            var SecSubTitle = $(this).find(".sub-title .word");
            var SecTitle = $(this).find(".title .word");
            TweenMax.set(SecSubTitle, { yPercent: 100, autoAlpha: 0 });
            TweenMax.set(SecTitle, { y: 25, autoAlpha: 0, rotationX: 90, transformOrigin: "bottom center" });
            SecTl = new TimelineMax();
            SecTl.staggerTo(SecSubTitle, 0.5, { yPercent: 0, autoAlpha: 1, ease: Expo.easeOut }, 0.01).staggerTo(SecTitle, 1, { y: 0, autoAlpha: 1, rotationX: 0, ease: Expo.easeOut }, 0.01).set(SecTitle, { transform: "" });
            new ScrollMagic.Scene({ triggerElement: this, triggerHook: 0.8, reverse: false }).setTween(SecTl).addTo(SMctrl);
        });
    }
    function CardsAni_Scripts() {
        let SMctrl = new ScrollMagic.Controller();
        $("[data-tooltip-thumb]").each(function () {
            var $this = $(this);
            var Src = $this.data("tooltip-thumb");
            var TooltipImg = $("<div class='img-tooltip'><span class='tooltip-bg' style='background-image:url(" + Src + ")'>");
            var TooltipBg = TooltipImg.find(".tooltip-bg");
            $this.on("mousemove", function (event) {
                TooltipImg.appendTo("body");
                TweenMax.to(TooltipImg, 0.2, { top: event.pageY - 30 + "px", left: event.pageX + 10 + "px" });
            });
            $this.hover(
                function () {
                    TweenMax.to(TooltipImg, 0.5, { width: "300px", ease: Expo.easeInOut });
                    TweenMax.to(TooltipBg, 0.5, { scale: 1, ease: Expo.easeInOut });
                },
                function () {
                    var TooltipTl = new TimelineMax({ onComplete: complete });
                    TweenMax.to(TooltipImg, 0.5, { width: "0", ease: Expo.easeInOut });
                    TooltipTl.to(TooltipBg, 0.5, { scale: 1.5, ease: Expo.easeInOut });
                    function complete() {
                        TooltipImg.remove();
                    }
                }
            );
        });
        $(".box-overlay-ani").each(function () {
            $(this).append('<span class="ani-overlaywrap"><span class="overlay">');
            var OverlayWrap = $(this).find(".ani-overlaywrap");
            var Overlay = $(this).find(".overlay");
            var ContentWrap = $(this).find(".content-wrap");
            TweenMax.set(Overlay, { x: "-100%" });
            TweenMax.set(ContentWrap, { autoAlpha: 0 });
            Tl = new TimelineMax();
            Tl.to(Overlay, 0.5, { x: "0%", ease: Expo.easeInOut }).to(ContentWrap, 0.1, { autoAlpha: 1, ease: Expo.easeInOut }).to(Overlay, 0.5, { x: "100%", ease: Expo.easeInOut }).set(OverlayWrap, { display: "none" });
            new ScrollMagic.Scene({ triggerElement: this, triggerHook: 0.8, reverse: false }).setTween(Tl).addTo(SMctrl);
        });
    }
    $(".popup-link").magnificPopup({ type: "image" });
    $(".popup-gallery").magnificPopup({ type: "image", gallery: { enabled: true } });
    $(".popup-youtube, .popup-vimeo, .popup-gmaps").magnificPopup({ type: "iframe", mainClass: "mfp-fade", removalDelay: 160, preloader: false, fixedContentPos: false });
    $(".magnific-mix-gallery").each(function () {
        var $container = $(this);
        var $imageLinks = $container.find(".item");
        var items = [];
        $imageLinks.each(function () {
            var $item = $(this);
            var type = "image";
            if ($item.hasClass("magnific-iframe")) {
                type = "iframe";
            }
            var magItem = { src: $item.attr("href"), type: type };
            magItem.title = $item.data("title");
            items.push(magItem);
        });
        $imageLinks.magnificPopup({
            mainClass: "mfp-fade",
            items: items,
            gallery: { enabled: true, tPrev: $(this).data("prev-text"), tNext: $(this).data("next-text") },
            type: "image",
            callbacks: {
                beforeOpen: function () {
                    var index = $imageLinks.index(this.st.el);
                    if (-1 !== index) {
                        this.goTo(index);
                    }
                },
            },
        });
    });
});
