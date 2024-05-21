const submitButton = document.getElementById("logout"); // Get the form by its ID
submitButton.addEventListener("click", function (event) {
        event.preventDefault(); // Prevent default form submission

        $.ajax({
            type: 'POST',
            url: '/User/LogoutUser',
            contentType: 'application/json; charset=utf-8',
        }).done(function (data) {
            self.result("Done!");
        })
        window.location.back();
    }
);
