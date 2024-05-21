const submitButton = document.getElementById("submitForm");
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];
    const comment = document.getElementById("comment").value;
    const dto = {
        comment: comment,
        userId: document.getElementById("userId").value
    }


    $.ajax({
        type: 'POST',
        url: '/Comment/AddComment/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
    }).done(function (data) {
        self.user(data.userName)
        self.result("Done!");
    })
    // .fail(showError);
    window.location.reload();
});

