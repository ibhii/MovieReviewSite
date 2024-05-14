const submitButton = document.getElementById("addGenre"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const movieId = window.location.pathname.split('/')[3];
    const genreId = document.getElementById("GenreId").value;

    const dto = {
        movieId : movieId,
        genreId : genreId
    }


    $.ajax({
        type: 'POST',
        url: '/Genre/AddGenreByMovieId',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
        headers: {
            User: localStorage.getItem("user"),
            Authorization: "bearer " + localStorage.getItem("token")
        }
    }).done(function (data) {
        self.result("Done!");
    })
    alert("Changes Applied!");
    window.location.reload();
});
