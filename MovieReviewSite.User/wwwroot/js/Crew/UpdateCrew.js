const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const firstName = document.getElementById("FirstName").value;
    const middleName = document.getElementById("MiddleName").value;
    const lastName = document.getElementById("LastName").value;
    const birthDate = document.getElementById("BirthDate").value;
    const id = window.location.pathname.split('/')[3];
    const userId = document.getElementById("userId").value
    
    const dto = {
        firstName: firstName || null,
        middleName: middleName || null,
        lastName: lastName || null,
        birthDate: birthDate || null,
        userId : userId
    }
    

    $.ajax({
        type: 'POST',
        url: '/Crew/UpdateCrew/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
    }).done(function (data) {
        self.result("Done!");
    })
    alert("Changes Applied!");
    window.location.reload();
});
