const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    alert("logged in")
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
            localStorage.setItem('userId', user.id);
            localStorage.setItem('name', user.name);
            localStorage.setItem('userName', user.username);
            localStorage.setItem('roleCode', user.roleCode);

            // Alternatively, store user object in a more structured way:
            localStorage.setItem('user', JSON.stringify(user));
            // Store the JWT in local storage (recommended)
            localStorage.setItem('token', data.token);
            self.result("Done!");
            alert("token is added to header")
        } else {
            // Handle error if token is missing
            console.error("Login failed: Token not received");
            self.result("Login failed");
            alert("Login failed: Token not received")
        }
    })
});
