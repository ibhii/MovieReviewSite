const submitButton = document.getElementById("submitForm"); // Get the form by its ID

submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const name = document.getElementById("Name").value;
    const synopsis = document.getElementById("Synopsis").value;
    const duration = document.getElementById("Duration").value;
    const releaseDate = document.getElementById("ReleaseDate").value;
    const type = document.getElementById("Type").value;
    const ageRate = document.getElementById("AgeRate").value;

    const movieData = {
        name: name,
        synopsis: synopsis,
        duration: duration,
        releaseDate: releaseDate,
        type: type,
        ageRate: ageRate
    };

    fetch("/Movie/AddMovie", { // Assuming an API endpoint for adding movies
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(movieData)
    })
        .then(response => response.json()) 
});
