const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const userName = document.getElementById("Username").value;
    const password = document.getElementById("Password").value;


    const dto = {
        userName: userName,
        password: password,
    }


    $.ajax({
        type: 'POST',
        url: '/User/LoginUser',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto)
    }).done(function (data) {
            self.result("Done!");
        }
    )
    alert("logged in")
    window.location.back()
});

function showPassword() {
    const x = document.getElementById("Password");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
