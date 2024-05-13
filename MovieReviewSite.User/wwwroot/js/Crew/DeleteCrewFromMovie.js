const submitButton = document.getElementById("addCrew"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    alert("AAAAAAAAA")
    const crewId = document.getElementById("movieCrewId").value
    const movieId = window.location.pathname.split('/')[3];
    const crewType = document.getElementById("movieCrewTypeCode").value

    const dto = {
        crewId: crewId,
        movieId: movieId,
        crewType: crewType
    }


    $.ajax({
        type: 'POST',
        url: '/Crew/RemoveCrewFromMovie/',
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
