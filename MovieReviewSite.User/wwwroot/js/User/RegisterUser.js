const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const firstName = document.getElementById("FirstName").value;
    const lastName = document.getElementById("LastName").value;
    const email = document.getElementById("Email").value;
    const userName = document.getElementById("UserName").value;
    const password = document.getElementById("Password").value;


    const dto = {
        firstName: firstName,
        lastName: lastName,
        email: email,
        userName: userName,
        password: password,
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
