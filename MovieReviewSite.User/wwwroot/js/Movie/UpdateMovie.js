const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const name = document.getElementById("DTO.Name").value;
    const synopsis = document.getElementById("DTO.Synopsis").value;
    const duration = document.getElementById("DTO.Duration").value;
    const releaseDate = document.getElementById("DTO.ReleaseDate").value;
    const ageRate = document.getElementById("DTO.AgeRate").value;
    const id = window.location.pathname.split('/')[3];

    const dto = {
        Name: name || "",
        Synopsis: synopsis || "",
        Duration: duration || 0,
        ReleaseDate: releaseDate || "",
        AgeRating: ageRate || 0,
    };

    fetch("/Movie/UpdateMovie/" + id , { // Assuming an API endpoint for adding movies
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(dto)
    })
        .then(response => response.json())
});
