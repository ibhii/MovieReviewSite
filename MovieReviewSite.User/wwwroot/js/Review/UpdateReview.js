const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const title = document.getElementById("Title").value;
    const review = document.getElementById("Review").value;
    const givenRate = document.getElementById("GivenRate").value;
    const id = window.location.pathname.split('/')[3];

    const reviewData = {
        title: title || "",
        review: review || "",
        givenRate: givenRate || 0,
        userId : localStorage.getItem("userId"),
    }
    

    $.ajax({
        type: 'POST',
        url: '/Movie/UpdateMovie/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
        headers: {
            User: localStorage.getItem("user"),
            Authorization: "bearer " + localStorage.getItem("token")
        }
    }).done(function (data) {
        self.result("Done!");
    })
});
