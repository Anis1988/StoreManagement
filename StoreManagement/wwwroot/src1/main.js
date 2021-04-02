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
    fetch("https://localhost:44369/api/customer").then(res => res.json().then(res => {
        customers = res;

    }));
  loginForm.addEventListener("submit", (e) => {
      
    e.preventDefault();
    clickStore();

    let mail = document.getElementById("mail").value.trim();
    let pass = document.getElementById("pass").value;
        
    for (var i = 0; i < customers.length; i++) {
        if (customers[i].userName === mail && customers[i].password === pass) {
            console.log(1234);

            localStorage.setItem("custf",customers[i].firstName);
            localStorage.setItem("custl",customers[i].lastName);
            localStorage.setItem("id",customers[i].customerId);
            
            

            location = "src/index.html";
        } else {
            console.log("Error");
            setFormMessage(loginForm, "error", "Invalid username/password combination");
        }

    }
  
  });

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
        } if (e.target.id === "signupFirstName"  && e.target.value.length < 5  ) {
            setInputError(inputElement, "First Name must be at lease 5 chars and no more than 50 and not blank");
        }
        if (e.target.id === "signupLastName"  && e.target.value.length < 5  ) {
            setInputError(inputElement, "Last Name must be at lease 5 chars and no more than 50 and not blank");
        }
        if (e.target.id === "signupEmail"  && e.target.type !=="email" && e.target.value.length < 10) {
            setInputError(inputElement, "First Name must be at lease 10 chars and no more than 50 and not blank");
        }
        if (e.target.id === "signupPassword"  && e.target.value.length < 8 ) {
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

            "FirstName": document.getElementById("signupFirstName").value.trim(),
            "LastName": document.getElementById("signupLastName").value.trim(),
            "UserName": document.getElementById("signupUsername").value.trim(),
            "Email": document.getElementById("signupEmail").value.trim(),
            "Password": document.getElementById("signupPassword").value.trim(),
        }

        fetch("https://localhost:44369/api/customer",
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            }).then(res => res.json()).catch(err => console.log("error", err));
    });
});


async function fetchStores() {
    
    try {
        let res = await fetch("https://localhost:44369/api/store");
        return await res.json();
    } catch (err) {
        console.log(err);
    }
}
const arra = [];
async function renderStores() {
    
    const stores = await fetchStores();
    stores.forEach(user => arra.push(user.locationName));
    console.log(arra);
}

renderStores();

var select = document.getElementById("stores"), arr = ["North Carolina", "Texas", "Florida", "Mississippi", "Pennsylvania", "Colorado", "Missouri", 
                                                    "North Dakota", "Virginia", "New Jersey", "Maryland", "New Jersey", "Oklahoma", "Florida", 
                                                    "California", "Wisconsin", "Georgia", "Arizona", "New York", "Missouri", "Texas"]
for (var i = 0; i < arr.length; i++) {
    var option = document.createElement("OPTION"),
        txt = document.createTextNode(arr[i]);
    option.appendChild(txt);
    option.setAttribute("value", arr[i]);
    select.insertBefore(option, select.lastChild);

}

function clickStore() {
    const e = document.getElementById("stores")
    var storeChosen = e.options[e.selectedIndex].text;
    localStorage.setItem("store", storeChosen);
}



