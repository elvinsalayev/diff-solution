const loginForm = document.querySelector(".login_form");
const login = document.querySelector(".login_username_or_email");
const loginPassword = document.querySelector(".login_password");

loginForm.addEventListener("submit", (e) => {
  e.preventDefault();
  checkLoginInputs(); // check if inputs are correct
}
);

function checkLoginInputs(){
  const loginValue = login.value.trim();
  const loginPasswordValue = loginPassword.value.trim();

  if (loginValue === "") {
    setErrorFor(login, "İstifadəçi adı boş ola bilməz!");
  } else {
    setSuccessFor(login);
  }
  if (loginPasswordValue === "") {
    setErrorFor(loginPassword, "Parol boş ola bilməz!");
  } else {
    setSuccessFor(loginPassword);
  }
  function setErrorFor(input, message) {
    const formControl = input.parentElement;
    const errorMessage = formControl.querySelector(".error_message");
    formControl.className = "login_form_control error";
    errorMessage.innerText = message;
  }
  function setSuccessFor(input) {
    const formControl = input.parentElement;
    formControl.className = "login_form_control success";
  }
  
}
