function setFormMessage(formElement, type, message) {
  var messageElement = formElement.querySelector(".form__message");

  messageElement.textContent = message;
  messageElement.classList.remove(
    "form__message--success",
    "form__message--error"
  );
  messageElement.classList.add(`form__message--${type}`);
}

function setInputError(inputElement, message) {
  inputElement.classList.add("form__input--error");
  inputElement.parentElement.querySelector(
    ".form__input-error-message"
  ).textContent = message;
}

function clearInputError(inputElement) {
  inputElement.classList.remove("form__input--error");
  inputElement.parentElement.querySelector(
    ".form__input-error-message"
  ).textContent = "";
}

document.addEventListener("DOMContentLoaded", () => {
  var loginForm = document.querySelector("#login");
  var createAccountForm = document.querySelector("#createAccount");

  document
    .querySelector("#linkCreateAccount")
    .addEventListener("click", (e) => {
      e.preventDefault();
      loginForm.classList.add("form--hidden");
      createAccountForm.classList.remove("form--hidden");
    });

  document.querySelector("#linkLogin").addEventListener("click", (e) => {
    e.preventDefault();
    loginForm.classList.remove("form--hidden");
    createAccountForm.classList.add("form--hidden");
  });

  let customers = [];
  fetch("https://localhost:44369/api/customer").then(res => res.json().then(res => (customers = res)));
  loginForm.addEventListener("submit", (e) => {
      
    e.preventDefault();
    
   
    let mail = document.getElementById("mail").value.trim();
    let pass = document.getElementById("pass").value;
    
      
      if (userExist(mail) && userExist2(pass)) {
          window.location.href = "src/index.html";
      } else {
          console.log(userExist(mail));
          console.log(mail);
          console.log("-----------------------------");
          console.log(userExist2(pass));
          console.log(pass);
          console.log(customers);
          setFormMessage(loginForm, "error", "Invalid username/password combination");
      }
  });

  function userExist(test) {
      return customers.some((el) => {
          return el.userName === test;
      });
  }
  function userExist2(test) {
      return customers.some((el) => {
          return el.password === test;

      });
  }

  document.querySelectorAll(".form__input").forEach((inputElement) => {
      inputElement.addEventListener("blur", (e) => {
        if (
            e.target.id === "signupUsername" &&
            e.target.value.length > 0 &&
            e.target.value.length < 10
        ) {
            setInputError(
                inputElement,
                "Username must be at least 10 characters in length"
            );
        } if (e.target.id === "signupFirstName"  && e.target.value.length < 5 && e.target.value.length > 2 ) {
            setInputError(inputElement, "First Name must be at lease 2 chars and no more than 50 and not blank");
        }
        if (e.target.id === "signupLastName"  && e.target.value.length < 5 && e.target.value.length > 2 ) {
            setInputError(inputElement, "Last Name must be at lease 2 chars and no more than 50 and not blank");
        }
        if (e.target.id === "signupEmail"  && e.target.type !=="email") {
            setInputError(inputElement, "First Name must be at lease 2 chars and no more than 50 and not blank");
        }
        if (e.target.id === "signupPassword"  && e.target.value.length < 12  ) {
            setInputError(inputElement, "Password must be at lease 12 chars");
        }
    });

    inputElement.addEventListener("input", (e) => {
      clearInputError(inputElement);
    });
  });

    document.getElementById("createSubmit").addEventListener('click', (e) => {
        e.preventDefault();

        var pass1 = document.getElementById("signupPassword").value;
        var pass2 = document.getElementById("signupPasswordConfirm").value;
        if (pass1 !== pass2) {
            document.querySelectorAll(".form__input").forEach((inputElement) => {
                inputElement.addEventListener("blur",
                    (e) => {
                        if (
                            e.target.id === "signupPassword" && pass1 !== pass2) {
                            setInputError(
                                inputElement,
                                "Password must Much"
                            );
                        }
                    });

            });
            return;
        }    
    
        const data = {

            "FirstName": document.getElementById("signupFirstName").value,
            "LastName": document.getElementById("signupLastName").value,
            "UserName": document.getElementById("signupUsername").value,
            "Email": document.getElementById("signupEmail").value,
            "Password": document.getElementById("signupPassword").value,
        }

        fetch("https://localhost:44369/api/customer",
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            }).then(res => res.json()).then(console.log("success: ", data)).catch(err => console.log("error", err));
    });
});
