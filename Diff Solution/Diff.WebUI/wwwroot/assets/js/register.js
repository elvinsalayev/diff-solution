const registerForm = document.querySelector(".register_form");
const registerName = document.querySelector(".register_name");
const registerSurname = document.querySelector(".register_surname");
const registerUsername = document.querySelector(".register_username");
const registerEmail = document.querySelector(".register_email");
const registerPassword = document.querySelector(".register_password");
const registerPasswordAgain = document.querySelector(
  ".register_password_again"
);

registerForm.addEventListener("submit", (e) => {
  e.preventDefault();
  checkRegisterInputs(); // check if inputs are correct
});

function checkRegisterInputs() {
  const registerNameValue = registerName.value.trim();
  const registerSurnameValue = registerSurname.value.trim();
  const registerUsernameValue = registerUsername.value.trim();
  const registerEmailValue = registerEmail.value.trim();
  const registerPasswordValue = registerPassword.value.trim();
  const registerPasswordAgainValue = registerPasswordAgain.value.trim();

  if (registerNameValue === "") {
    setErrorFor(registerName, "Ad boş ola bilməz!");
  } else {
    setSuccessFor(registerName);
  }

  if (registerSurnameValue === "") {
    setErrorFor(registerSurname, "Soyad boş ola bilməz!");
  } else {
    setSuccessFor(registerSurname);
  }
  if (registerUsernameValue === "") {
    setErrorFor(registerUsername, "İstifadəçi adı boş ola bilməz!");
  } else {
    setSuccessFor(registerUsername);
  }
  if (registerEmailValue === "") {
    setErrorFor(registerEmail, "Email boş ola bilməz!");
  } else if (!isEmail(registerEmailValue)) {
    setErrorFor(registerEmail, "Düzgün email daxil edin!");
  } else {
    setSuccessFor(registerEmail);
  }
  if (registerPasswordValue === "") {
    setErrorFor(registerPassword, "Parol boş ola bilməz!");
  } else if (registerPasswordValue.length < 8) {
    setErrorFor(registerPassword, "Şifrə minimum 8 simvol olmalıdır!");
  } else {
    setSuccessFor(registerPassword);
  }
  if (registerPasswordAgainValue === "") {
    setErrorFor(registerPasswordAgain, "Parol boş ola bilməz!");
  } else if (registerPasswordAgainValue !== registerPasswordValue) {
    setErrorFor(registerPasswordAgain, "Şifrələr eyni olmalıdır!");
  } else {
    setSuccessFor(registerPasswordAgain);
  }
  function setErrorFor(input, message) {
    const formControl = input.parentElement;
    const errorMessage = formControl.querySelector(".error_message");
    formControl.className = "register_form_control error";
    errorMessage.innerText = message;
  }
  function setSuccessFor(input) {
    const formControl = input.parentElement;
    formControl.className = "register_form_control success";
  }
  function isEmail(registerEmail) {
    return /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test(
      registerEmail
    );
  }
}