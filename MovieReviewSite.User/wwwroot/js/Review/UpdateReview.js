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
        userId:6,
    }

//     fetch("/Movie/UpdateMovie/" + id , { // Assuming an API endpoint for adding movies
//         method: "POST",
//         headers: {
//             "Content-Type": "application/json"
//         },
//         body: JSON.stringify(reviewData)
//     })
//         .then(response => response.json())
// });

// //getting authorizing token
// const token = localStorage.getItem('accessToken');
// if (!token) {
//     console.error("Missing access token for authorized request");
//     return; // Handle missing token scenario
// }

    $.ajax({
        type: 'POST',
        url: '/Movie/UpdateMovie/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
        // headers: {
        //    Authorization:  "bearer " + localStorage.getItem("token")
        // }
    }).done(function (data) {
        self.result("Done!");
    })
});
