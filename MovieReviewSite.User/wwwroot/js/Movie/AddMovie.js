const submitButton = document.getElementById("submitForm"); //// Get the form by its ID

submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const name = document.getElementById("Name").value;
    const synopsis = document.getElementById("Synopsis").value;
    const duration = document.getElementById("Duration").value;
    const releaseDate = document.getElementById("ReleaseDate").value;
    const ageRate = document.getElementById("AgeRate").value;

    const dto = {
        name: name,
        synopsis: synopsis,
        Duration: duration,
        ReleaseDate: releaseDate,
        ageRating: ageRate,
        createdById : 6,
    };

    fetch("/Movie/AddMovie", { // Assuming an API endpoint for adding movies
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(dto)
    })
        .then(response => response.json()) 
});
