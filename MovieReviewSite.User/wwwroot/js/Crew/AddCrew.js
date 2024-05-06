const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const firstName = document.getElementById("FirstName").value;
    const middleName = document.getElementById("MiddleName").value;
    const lastName = document.getElementById("LastName").value;
    const birthDate = document.getElementById("BirthDate").value;

    const dto = {
        firstName: firstName,
        middleName: middleName,
        lastName: lastName,
        createdBy: 6,
        birthDate: birthDate,
    }

    fetch("/Crew/AddCrew", { // Assuming an API endpoint for adding movies
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(dto)
    })
        .then(response => response.json())
});
