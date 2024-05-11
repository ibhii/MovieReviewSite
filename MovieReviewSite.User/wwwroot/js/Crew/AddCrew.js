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
        createdBy: localStorage.getItem("userId"),
        birthDate: birthDate || null,
    }


    $.ajax({
        type: 'POST',
        url: '/Crew/AddCrew',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
        headers: {
            User: localStorage.getItem("user"),
            Authorization: "bearer " + localStorage.getItem("token")
        }
    }).done(function (data) {
        self.result("Done!");
    })
});
