const submitButton = document.getElementById("comment");
submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];
    const comment = document.getElementById("comment").value;

    const dto = {
        comment: comment,
        userId:6
    }

    // fetch("/Comment/AddComment/" + id, { // Assuming an API endpoint for adding movies
    //     method: "POST",
    //     headers: {
    //         "Content-Type": "application/json"
    //     },
    //     body: JSON.stringify(commentData)
    // })
    //     .then(response => response.json())
    $.ajax({
        type: 'POST',
        url: '/Comment/AddComment/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto)
    }).done(function (data) {
        self.user(data.userName)
        self.result("Done!");
    })
    // .fail(showError);
});

