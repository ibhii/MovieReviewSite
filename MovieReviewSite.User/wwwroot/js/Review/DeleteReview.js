const deleteButton = document.getElementById("deleteReview");
deleteButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];
    const userId = localStorage.getItem("userId")


    $.ajax({
        type: 'POST',
        url: '/Review/DeleteReview/' + id,
        contentType : 'application/json; charset=utf-8',
        data: JSON.stringify(userId),
        headers: {
            User: localStorage.getItem("user"),
            Authorization: "bearer " + localStorage.getItem("token")
        },
    }).done(function (data) {
        self.result("Done!");
    })
// .fail(showError);
});
