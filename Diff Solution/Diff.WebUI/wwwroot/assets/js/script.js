let swiperProducts = new Swiper(".new_collection_container", {
  spaceBetween: 30,
  grabCursor: true,
  centeredSlides: true,
  slidesPerView: 4,
  loop: true,
  speed: 1500,
  autoplay: {
    delay: 1000,

    disableOnInteraction: false,
  },
  navigation: {
    nextEl: ".swiper-button-next",
    prevEl: ".swiper-button-prev",
  },
  breakpoints: {
    1920: {
      slidesPerView: 3,
      spaceBetween: 30,
    },
    960: {
      slidesPerView: 3,
      spaceBetween: 30,
    },
    640: {
      slidesPerView: 1,
      spaceBetween: 50,
    },
    480: {
      slidesPerView: 1,
      spaceBetween: 30,
    },
    280: {
      slidesPerView: 1,
      spaceBetween: 20,
    },
  },
});
let swiperBanners = new Swiper(".banner_section", {
  spaceBetween: 10,
  centeredSlides: true,
  slidesPerView: 1,
  simulateTouch: false,
  loop: true,
  autoplay: {
    delay: 3000,
    disableOnInteraction: false,
  },
  effect: "fade",
  fadeEffect: {
    crossFade: true,
  },
  keyboard: {
    enabled: true,
    onlyInViewport: false,
  },

  // shortSwipes: false,
  // slideToClickedSlide: false,
  // preventClicksPropagation: false,
  // preventClicks: false,
});

$(".add-button").click(function () {
  for (var i = 0; i < $(".add-button").length; i++) {
    $(".bottom").addClass("clicked");
  }
});

$(".remove-button").click(function () {
  $(".bottom").removeClass("clicked");
});

const sr = ScrollReveal();

sr.reveal(".header", {
  duration: 2000,
  origin: "top",
  distance: "200px",
  reset: true,
});

sr.reveal(".sale_banner", {
  origin: "bottom",
  distance: "200px",
  duration: 2000,
});

sr.reveal(".new_collection_section", {
  origin: "bottom",
  delay: 500,
  duration: 2000,
  distance: "200px",
});

sr.reveal(".footer", {
  origin: "bottom",
  distance: "100px",
  duration: 2000,
});

//add-to-cart

// dark mode
// $(".dark-mode").toggleClass("dark-mode-active");

const openSidebarMenuButton = document.querySelector(".nav_menu_button");
const sidebarMenu = document.querySelector(".sidebar_menu");
const closeSidebarMenuButton = document.querySelector(
  ".sidebar_menu_close_button"
);

openSidebarMenuButton.addEventListener("click", function () {
  sidebarMenu.classList.add("sidebar_menu_open");
});
closeSidebarMenuButton.addEventListener("click", function () {
  sidebarMenu.classList.remove("sidebar_menu_open");
});

const openCartButton = document.querySelector(".cart_button");
const cart = document.querySelector(".cart");

openCartButton.addEventListener("click", function () {
  cart.classList.add("cart_open");
});

//cart
const cartProductPrice = document.querySelectorAll(
  ".cart_product_price_amount_value"
);
const cartProductSubtotal = document.querySelectorAll(
  ".cart_product_subtotal_amount_value"
);
const cartProductQuantityNumber = document.querySelectorAll(
  ".cart_product_quantity_number"
);
const cartProductQuantityMinus = document.querySelectorAll(
  ".cart_product_quantity_minus"
);
const cartProductQuantityPlus = document.querySelectorAll(
  ".cart_product_quantity_plus"
);

const QuantityChange = () => {
  for (let i = 0; i < cartProductQuantityNumber.length; i++) {
    let cartProductQuantityNumberValue = parseInt(
      cartProductQuantityNumber[i].textContent
    );
    //plus
    cartProductQuantityPlus[i].addEventListener("click", function () {
      cartProductQuantityNumberValue++;
      cartProductQuantityNumber[i].textContent = cartProductQuantityNumberValue;
    });
    //minus
    cartProductQuantityMinus[i].addEventListener("click", function () {
      if (cartProductQuantityNumberValue > 0) {
        cartProductQuantityNumberValue--;
        cartProductQuantityNumber[i].textContent =
          cartProductQuantityNumberValue;
      } else {
        cartProductQuantityNumber[i].textContent = 0;
      }
    });
  }
};
QuantityChange();

//subtotal






toastr.options = {
    "closeButton": true,
    "debug": true,
    "newestOnTop": false,
    "progressBar": true,
    "positionClass": "toast-bottom-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
}


