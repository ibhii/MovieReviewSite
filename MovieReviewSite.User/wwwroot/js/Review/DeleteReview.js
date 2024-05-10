const deleteButton = document.getElementById("deleteReview");
deleteButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];

    // //getting authorizing token
// const token = localStorage.getItem('accessToken');
// if (!token) {
//     console.error("Missing access token for authorized request");
//     return; // Handle missing token scenario
// }

    $.ajax({
        type: 'POST',
        url: '/Review/DeleteReview/' + id,
        // headers: {
        //    Authorization:  "bearer " + localStorage.getItem("token")
        // }
        contentType: 'application/json; charset=utf-8',
    }).done(function (data) {
        self.result("Done!");
    })
// .fail(showError);
});
