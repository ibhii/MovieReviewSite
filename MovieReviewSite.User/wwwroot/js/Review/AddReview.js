const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];
    const title = document.getElementById("Title").value;
    const review = document.getElementById("Review").value;
    const givenRate = document.getElementById("GivenRate").value;
    const userId = document.getElementById("userId").value


    const dto = {
        title: title,
        review: review,
        givenRate: givenRate,
        userId: userId,
    }
    
    $.ajax({
        type: 'POST',
        url: '/Review/AddReview/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
    }).done(function (data) {
        self.result("Done!");
    })
    alert("Changes Applied!");
    window.location.back();
});
