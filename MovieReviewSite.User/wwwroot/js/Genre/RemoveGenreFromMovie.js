const submitButton = document.getElementById("deleteGenre"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    alert("AAAAAAAAA")
    const movieId = window.location.pathname.split('/')[3];
    const genreId = document.getElementById("movieGenreId").value;

    const dto = {
        movieId : movieId,
        genreId : genreId
    }


    $.ajax({
        type: 'POST',
        url: '/Crew/UpdateCrew/',
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
