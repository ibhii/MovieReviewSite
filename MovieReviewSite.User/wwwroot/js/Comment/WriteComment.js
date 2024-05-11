const submitButton = document.getElementById("submitForm");
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];
    const comment = document.getElementById("comment").value;
    const dto = {
        comment: comment,
        userId: localStorage.getItem("userId")
    }
    

    $.ajax({
        type: 'POST',
        url: '/Comment/AddComment/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
        headers: {
            User: localStorage.getItem("user"),
            Authorization: "bearer " + localStorage.getItem("token")
        }
    }).done(function (data) {
        self.user(data.userName)
        self.result("Done!");
    })
    // .fail(showError);
});

