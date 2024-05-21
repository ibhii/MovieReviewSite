const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    
    const name = document.getElementById("Name").value;
    const synopsis = document.getElementById("Synopsis").value;
    const duration = document.getElementById("Duration").value;
    const releaseDate = document.getElementById("ReleaseDate").value;
    const ageRate = document.getElementById("AgeRate").value;
    const id = window.location.pathname.split('/')[3];
    const userId = document.getElementById("userId").value


    const dto = {
        Name: name || null,
        Synopsis: synopsis || null,
        Duration: duration || 0,
        ReleaseDate: releaseDate || null,
        AgeRate: ageRate || null,
        UserId: userId,
    };
    
    

$.ajax({
    type: 'POST',
    url: '/Movie/UpdateMovie/' + id,
    contentType: 'application/json; charset=utf-8',
    data: JSON.stringify(dto),
    headers: {
        User: localStorage.getItem("user"),
        Authorization: "Bearer " + localStorage.getItem("token")
    }
}).done(function (data) {
    self.result("Done!");

})
    alert("Changes Applied!");
    window.location.reload();
});
