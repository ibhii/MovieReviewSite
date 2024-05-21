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
            if (data.token) { // Check if token exists in the response
                const user = data.user; // Assuming user information is in "user" property
                // Store user information
                self.result("Done!");
                alert("logged in")
                window.location.back()
            } else {
                const errorMessage = data.error?.message || "Login failed: Unexpected error";
                console.error("Login failed:", errorMessage);
                self.result("Login failed");
                alert(errorMessage);
            }
        }
    )
});
