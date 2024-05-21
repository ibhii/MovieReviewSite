const submitButton = document.getElementById("submitForm"); //// Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission

    const name = document.getElementById("Name").value;
    const synopsis = document.getElementById("Synopsis").value;
    const duration = document.getElementById("Duration").value;
    const releaseDate = document.getElementById("ReleaseDate").value;
    const ageRate = document.getElementById("AgeRate").value;
    const userId = document.getElementById("userId").value


    const dto = {
        name: name || null,
        synopsis: synopsis || null,
        Duration: duration || 0,
        ReleaseDate: releaseDate || null,
        ageRate: ageRate || 0,
        UserId: userId,
    };

    $.ajax({
        type: 'POST',
        url: '/Movie/AddMovie/',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
    }).done(function (data) {
        self.result("Done!");
    })
    alert("Movie Added!");
    // window.location.reload();
});
