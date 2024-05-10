const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const firstName = document.getElementById("FirstName").value;
    const middleName = document.getElementById("MiddleName").value;
    const lastName = document.getElementById("LastName").value;
    const birthDate = document.getElementById("BirthDate").value;
    const id = window.location.pathname.split('/')[3];
    
    const dto = {
        firstName: firstName || null,
        middleName: middleName || null,
        lastName: lastName || null,
        birthDate: birthDate || null,
        createdBy: 6,
    }
    
// //getting authorizing token
// const token = localStorage.getItem('accessToken');
// if (!token) {
//     console.error("Missing access token for authorized request");
//     return; // Handle missing token scenario
// }

    $.ajax({
        type: 'POST',
        url: '/Crew/UpdateCrew/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
        // headers: {
        //     'Authorization': `Bearer ${token}`
        // }
    }).done(function (data) {
        self.result("Done!");
    })
});
