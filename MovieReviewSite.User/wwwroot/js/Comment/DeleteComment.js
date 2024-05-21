const deleteButton = document.getElementById("deleteComment");
deleteButton.addEventListener("click", function (event) {
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
});
