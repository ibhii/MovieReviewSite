const submitButton = document.getElementById("submitForm"); // Get the form by its ID
submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    alert("Changes Applied!");

    const firstName = document.getElementById("FirstName").value;
    const lastName = document.getElementById("LastName").value;
    const email = document.getElementById("Email").value;
    const username = document.getElementById("Username").value;
    const birthDate = document.getElementById("BirthDate").value;
    const id = window.location.pathname.split('/')[3];

    const dto = {
        firstName : firstName || null,
        lastName : lastName || null,
        email : email || null,
        username : username || null,
        birthDate : birthDate || null,
        modifierId  : localStorage.getItem("userId"),
        modifierRoleCode : localStorage.getItem("roleCode")
    };
    
    $.ajax({
        type: 'POST',
        url: '/User/UpdateUser/' + id,
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
