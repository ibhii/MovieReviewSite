const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const firstName = document.getElementById("FirstName").value;
    const lastName = document.getElementById("LastName").value;
    const email = document.getElementById("Email").value;
    const userName = document.getElementById("UserName").value;
    const password = document.getElementById("Password").value;
    const repeatedPassword = document.getElementById("repeatPassword").value;


    const dto = {
        firstName: firstName,
        lastName: lastName,
        email: email,
        userName: userName,
        password: password,
    }
    
    if (password === repeatedPassword) {
        alert("Passwords Dont Match!")
    }

    $.ajax({
        type: 'POST',
        url: '/User/AddUser',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto)
    }).done(function (data) {
        self.result("Done!");
    })
    // .fail(showError);
});

function showPassword() {
    const x = document.getElementById("Password");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}

function showRepeatedPassword() {
    const x = document.getElementById("repeatPassword");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
