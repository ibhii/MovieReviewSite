const deleteButton = document.getElementById("deleteReview");
deleteButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];
    const userId = document.getElementById("userId").value


    $.ajax({
        type: 'POST',
        url: '/Review/DeleteReview/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(userId),
        headers: {
            User: localStorage.getItem("user"),
            Authorization: "Bearer " + localStorage.getItem("token")
        },
    }).done(function (data) {
        self.result("Done!");
    })
    alert("Review deleted!")
    window.location.back()
// .fail(showError);
});

const deleteButton2 = document.getElementById("deleteComment");
deleteButton2.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const id = document.getElementById("commentId").value;
    const userId = document.getElementById("userId").value



    $.ajax({
        type: 'POST',
        url: '/Comment/DeleteComment/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(userId),
    }).done(function (data) {
        self.result("Done!");
    })
    window.location.reload();
});
