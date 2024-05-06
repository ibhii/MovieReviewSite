const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const firstName = document.getElementById("DTO!.FirstName").value;
    const middleName = document.getElementById("DTO!.MiddleName").value;
    const lastName = document.getElementById("DTO!.LastName").value;
    const birthDate = document.getElementById("DTO!.BirthDate").value;
    const id = window.location.pathname.split('/')[3];


    const dto = {
        firstName: firstName,
        middleName: middleName,
        lastName: lastName,
        createdBy: 6,
        birthDate: birthDate,
    }

    fetch("/Crew/AddCrew/" + id ,{ // Assuming an API endpoint for adding movies
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(dto)
    })
        .then(response => response.json())
});
