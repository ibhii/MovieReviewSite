const deleteButton = document.getElementById("deleteReview");
deleteButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];
    

    $.ajax({
        type: 'POST',
        url: '/Review/DeleteReview/' + id,
        headers: {
            User: localStorage.getItem("user"),
            Authorization: "bearer " + localStorage.getItem("token")
        },
        contentType: 'application/json; charset=utf-8',
    }).done(function (data) {
        self.result("Done!");
    })
// .fail(showError);
});
