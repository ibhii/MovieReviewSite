const submitButton = document.getElementById("submitForm"); //// Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    alert("Movie Added!");

    const name = document.getElementById("Name").value;
    const synopsis = document.getElementById("Synopsis").value;
    const duration = document.getElementById("Duration").value;
    const releaseDate = document.getElementById("ReleaseDate").value;
    const ageRate = document.getElementById("AgeRate").value;
    //
    const dto = {
        name: name || null,
        synopsis: synopsis || null,
        Duration: duration || 0,
        ReleaseDate: releaseDate || null,
        ageRating: ageRate || 0,
        UserId: localStorage.getItem("userId"),
    };



    $.ajax({
        type: 'POST',
        url: '/Movie/AddMovie/',
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
