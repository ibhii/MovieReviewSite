const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    alert("Changes Applied!");
    
    const name = document.getElementById("Name").value;
    const synopsis = document.getElementById("Synopsis").value;
    const duration = document.getElementById("Duration").value;
    const releaseDate = document.getElementById("ReleaseDate").value;
    const ageRate = document.getElementById("AgeRate").value;
    const id = window.location.pathname.split('/')[3];

    const dto = {
        Name: name || null,
        Synopsis: synopsis || null,
        Duration: duration || 0,
        ReleaseDate: releaseDate || null,
        AgeRating: ageRate || null,
    };
    

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
