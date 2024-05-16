const submitButton = document.getElementById("addCrew"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const crewId = document.getElementById("crewId").value
    const movieId = window.location.pathname.split('/')[3];
    const crewType = document.getElementById("typeCode").value

    const dto = {
        crewId: crewId,
        movieId: movieId,
        crewType: crewType
    }


    $.ajax({
        type: 'POST',
        url: '/Crew/AddCrewToMovie',
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
