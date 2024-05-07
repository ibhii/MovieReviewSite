const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const userName = document.getElementById("UserName").value;
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
        self.user(data.userName)
        // Cache the access token in session storage.
        // sessionStorage.setItem(tokenKey, data.access_token);
        self.result("Done!");
    })
    // .fail(showError);
});
