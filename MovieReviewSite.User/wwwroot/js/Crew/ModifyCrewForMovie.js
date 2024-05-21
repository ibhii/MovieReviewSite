const addButton = document.getElementById("addCrew"); // Get the form by its ID
addButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const crewId = document.getElementById("crewId").value
    const movieId = window.location.pathname.split('/')[3];
    const crewType = document.getElementById("typeCode").value;


    const dto = {
        crewId: crewId,
        movieId: movieId,
        crewType: crewType,
    }


    $.ajax({
        type: 'POST',
        url: '/Crew/AddCrewToMovie',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
    }).done(function (data) {
        self.result("Done!");
    })
    alert("Changes Applied!");
    window.location.reload();
});

const removeButton = document.getElementById("deleteCrew"); // Get the form by its ID
removeButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const crewId = document.getElementById("movieCrewId").value
    const movieId = window.location.pathname.split('/')[3];
    const crewType = document.getElementById("movieCrewTypeCode").value;


    const dto = {
        crewId: crewId,
        movieId: movieId,
        crewType: crewType,
    }


    $.ajax({
        type: 'POST',
        url: '/Crew/RemoveCrewFromMovie',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
    }).done(function (data) {
        self.result("Done!");
    })
    alert("Changes Applied!");
    window.location.reload();
});
