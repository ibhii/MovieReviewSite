const submitButton = document.getElementById("submitLike"); // Use the form ID

submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const id = document.getElementById("Id").value;


    const reviewData = {
        id: id
    }

    fetch("/Review/LikeReview", { // Assuming an API endpoint for adding movies
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(reviewData)
    })
        .then(response => response.json())
});
