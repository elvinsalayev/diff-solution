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
  distance: "200px"
});

sr.reveal(".sale_banner", {
  origin: "bottom",
  distance: "200px",
  duration: 2000
});

sr.reveal(".new_collection_section", {
  origin: "bottom",
  delay: 500,
  duration: 2000,
  distance: "200px"
});

sr.reveal(".footer", {
  origin: "bottom",
  distance: "100px",
  duration: 2000
});

//add-to-cart

// dark mode
// $(".dark-mode").toggleClass("dark-mode-active");


// const openSidebarMenuButton = document.querySelector(".nav_menu_button");
// const sidebarMenu = document.querySelector(".sidebar_menu");
// const closeSidebarMenuButton = document.querySelector(
//   ".sidebar_menu_close_button"
// );
// openSidebarMenuButton.addEventListener("click", function () {
//   sidebarMenu.classList.add("sidebar_menu_open");
// });
// closeSidebarMenuButton.addEventListener("click", function () {
//   sidebarMenu.classList.remove("sidebar_menu_open");
// });


//sidebar menu
$('.nav_menu_button').click(function () {
  $('.sidebar_menu').addClass('sidebar_menu_open');
});
$('.sidebar_menu_close_button').click(function () {
  $('.sidebar_menu').removeClass('sidebar_menu_open');
});
$(document).mouseup(function (e) {
  if ($(e.target).closest(".sidebar_menu_open").length === 0) {
    $(".sidebar_menu_open").removeClass("sidebar_menu_open");
  }
});



//account dropdown menu
$('.account_icon').hover(function () {
  $('.account_dropdown_menu').toggleClass('account_dropdown_menu_open');
});
$('.account_dropdown_menu').hover(function () {
  $('.account_dropdown_menu').toggleClass('account_dropdown_menu_open');
});


//account dropdown menu
$('.account_icon').hover(function () {
  $('.account_dropdown_menu_login_success').toggleClass('account_dropdown_menu_login_success_open');
});
$('.account_dropdown_menu_login_success').hover(function () {
  $('.account_dropdown_menu_login_success').toggleClass('account_dropdown_menu_login_success_open');
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



//scroll top button
$(window).scroll(function () {
  if ($(window).scrollTop() > 100) {
    $('.scroll_top_button').addClass('scroll_top_button_show');
  } else {
    $('.scroll_top_button').removeClass('scroll_top_button_show');
  }
});

$('.scroll_top_button').click(function () {
  $("html, body").animate({ scrollTop: 0 });
});

//subtotal




function clickEffect() {
  let balls = [];
  let longPressed = false;
  let longPress;
  let multiplier = 0;
  let width, height;
  let origin;
  let normal;
  let ctx;
  const colours = ["#4fff79", "#4fff79", "#4fff79", "#4fff79", "#4fff79"];
  const canvas = document.createElement("canvas");
  document.body.appendChild(canvas);
  canvas.setAttribute("style", "width: 100%; height: 100%; top: 0; left: 0; z-index: 99999; position: fixed; pointer-events: none;");
  const pointer = document.createElement("span");
  pointer.classList.add("pointer");
  document.body.appendChild(pointer);
 
  if (canvas.getContext && window.addEventListener) {
    ctx = canvas.getContext("2d");
    updateSize();
    window.addEventListener('resize', updateSize, false);
    loop();
    window.addEventListener("mousedown", function(e) {
      pushBalls(randBetween(10, 20), e.clientX, e.clientY);
      document.body.classList.add("is-pressed");
      longPress = setTimeout(function(){
        document.body.classList.add("is-longpress");
        longPressed = true;
      }, 500);
    }, false);
    window.addEventListener("mouseup", function(e) {
      clearInterval(longPress);
      if (longPressed == true) {
        document.body.classList.remove("is-longpress");
        pushBalls(randBetween(50 + Math.ceil(multiplier), 100 + Math.ceil(multiplier)), e.clientX, e.clientY);
        longPressed = false;
      }
      document.body.classList.remove("is-pressed");
    }, false);
    window.addEventListener("mousemove", function(e) {
      let x = e.clientX;
      let y = e.clientY;
      pointer.style.top = y + "px";
      pointer.style.left = x + "px";
    }, false);
  } else {
    console.log("canvas or addEventListener is unsupported!");
  }
 
 
  function updateSize() {
    canvas.width = window.innerWidth * 2;
    canvas.height = window.innerHeight * 2;
    canvas.style.width = window.innerWidth + 'px';
    canvas.style.height = window.innerHeight + 'px';
    ctx.scale(2, 2);
    width = (canvas.width = window.innerWidth);
    height = (canvas.height = window.innerHeight);
    origin = {
      x: width / 2,
      y: height / 2
    };
    normal = {
      x: width / 2,
      y: height / 2
    };
  }
  class Ball {
    constructor(x = origin.x, y = origin.y) {
      this.x = x;
      this.y = y;
      this.angle = Math.PI * 2 * Math.random();
      if (longPressed == true) {
        this.multiplier = randBetween(14 + multiplier, 15 + multiplier);
      } else {
        this.multiplier = randBetween(6, 12);
      }
      this.vx = (this.multiplier + Math.random() * 0.5) * Math.cos(this.angle);
      this.vy = (this.multiplier + Math.random() * 0.5) * Math.sin(this.angle);
      this.r = randBetween(8, 12) + 3 * Math.random();
      this.color = colours[Math.floor(Math.random() * colours.length)];
    }
    update() {
      this.x += this.vx - normal.x;
      this.y += this.vy - normal.y;
      normal.x = -2 / window.innerWidth * Math.sin(this.angle);
      normal.y = -2 / window.innerHeight * Math.cos(this.angle);
      this.r -= 0.3;
      this.vx *= 0.9;
      this.vy *= 0.9;
    }
  }
 
  function pushBalls(count = 1, x = origin.x, y = origin.y) {
    for (let i = 0; i < count; i++) {
      balls.push(new Ball(x, y));
    }
  }
 
  function randBetween(min, max) {
    return Math.floor(Math.random() * max) + min;
  }
 
  function loop() {
    ctx.fillStyle = "rgba(255, 255, 255, 0)";
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    for (let i = 0; i < balls.length; i++) {
      let b = balls[i];
      if (b.r < 0) continue;
      ctx.fillStyle = b.color;
      ctx.beginPath();
      ctx.arc(b.x, b.y, b.r, 0, Math.PI * 2, false);
      ctx.fill();
      b.update();
    }
    if (longPressed == true) {
      multiplier += 0.2;
    } else if (!longPressed && multiplier >= 0) {
      multiplier -= 0.4;
    }
    removeBall();
    requestAnimationFrame(loop);
  }
 
  function removeBall() {
    for (let i = 0; i < balls.length; i++) {
      let b = balls[i];
      if (b.x + b.r < 0 || b.x - b.r > width || b.y + b.r < 0 || b.y - b.r > height || b.r < 0) {
        balls.splice(i, 1);
      }
    }
  }
}
clickEffect();