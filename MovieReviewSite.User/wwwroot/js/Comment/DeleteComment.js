const deleteButton = document.getElementById("deleteButton");
deleteButton.addEventListener("click", function(event) {
    event.preventDefault(); // Prevent default form submission

    const id = window.location.pathname.split('/')[3];

    fetch("/Review/DeleteReview/" + id, {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json"
        },
    })
        .then(response => response.json())
    // Handle the response (success or error)
});
