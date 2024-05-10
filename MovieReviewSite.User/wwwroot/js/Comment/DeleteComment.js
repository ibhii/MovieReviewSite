const deleteButton = document.getElementById("deleteButton");
deleteButton.addEventListener("click", function(event) {
    event.preventDefault(); // Prevent default form submission

    const id = window.location.pathname.split('/')[3];

//     fetch("/Review/DeleteReview/" + id, {
//         method: "DELETE",
//         headers: {
//             "Content-Type": "application/json"
//         },
//     })
//         .then(response => response.json())
//     // Handle the response (success or error)
// });

// //getting authorizing token
// const token = localStorage.getItem('accessToken');
// if (!token) {
//     console.error("Missing access token for authorized request");
//     return; // Handle missing token scenario
// }

$.ajax({
    type: 'POST',
    url: '/Review/DeleteReview/' + id,
    contentType: 'application/json; charset=utf-8',
    // headers: {
    //    Authorization:  "bearer " + localStorage.getItem("token")
    // }
}).done(function (data) {
    self.result("Done!");
})
});
