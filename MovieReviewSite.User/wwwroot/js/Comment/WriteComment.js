const submitButton = document.getElementById("comment");
submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];
    const comment = document.getElementById("comment").value;

    const commentData = {
        comment: comment,
        userId:6
    }

    fetch("/Comment/AddComment/" + id, { // Assuming an API endpoint for adding movies
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(commentData)
    })
        .then(response => response.json())
});

