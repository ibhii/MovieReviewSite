const addButton = document.getElementById("addGenre"); // Get the form by its ID
addButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const movieId = window.location.pathname.split('/')[3];
    const genreId = document.getElementById("GenreId").value;

    const dto = {
        movieId : movieId,
        genreId : genreId,
    }


    $.ajax({
        type: 'POST',
        url: '/Genre/AddGenreByMovieId',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
    }).done(function (data) {
        self.result("Done!");
    })
    alert("Changes Applied!");
    window.location.reload();
});

const removeButton = document.getElementById("deleteGenre"); // Get the form by its ID
removeButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const movieId = window.location.pathname.split('/')[3];
    const genreId = document.getElementById("movieGenreId").value;


    const dto = {
        movieId : movieId,
        genreId : genreId,
    }


    $.ajax({
        type: 'POST',
        url: '/Genre/RemoveGenreByMovieId',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
        
    }).done(function (data) {
        self.result("Done!");
    })
    alert("Changes Applied!");
});

