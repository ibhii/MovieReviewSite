const deleteButton = document.getElementById("deleteCrew");
deleteButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];

    fetch("/Crew/DeleteCrew/" + id, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
    })
        .then(response => response.json())
    // Handle the response (success or error)
});
