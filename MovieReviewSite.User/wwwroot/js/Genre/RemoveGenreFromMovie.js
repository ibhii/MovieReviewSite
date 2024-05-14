const submitButton = document.getElementById("deleteGenre"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const movieId = window.location.pathname.split('/')[3];
    const genreId = document.getElementById("movieGenreId").value;

    // const dto = {
    //     movieId : movieId,
    //     genreId : genreId
    // }

    const genre = {
        movieId : movieId,
        genreId : genreId
    }


    $.ajax({
        type: 'POST',
        url: '/Genre/RemoveGenreByMovieId',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(genre),
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
