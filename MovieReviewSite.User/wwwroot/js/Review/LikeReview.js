const submitButton = document.getElementById("like"); // Use the form ID

submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const id = document.getElementById("reviewId").value;


    const reviewData = {
        
    }

    fetch("/Review/LikeReview" + id, { // Assuming an API endpoint for adding movies
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(reviewData)
    })
        .then(response => response.json())
});
