const deleteButton = document.getElementById("deleteReview");
deleteButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission

    const currentPassword = document.getElementById("CurrentPassword").value;
    const newPassword = document.getElementById("NewPassword").value;
    const repeatedPassword = document.getElementById("RepeatedPassword").value;
    const password = document.getElementById("Password").value;

    if (newPassword !== currentPassword) {
     alert("Please enter a new password")   
    }
    if(repeatedPassword !== newPassword){
        alert("New Password and the repeated on dont match!")
    }
    const id = window.location.pathname.split('/')[3];
    const dto = {
        id: localStorage.getItem("userId"),
        roleCode: localStorage.getItem("roleCode")
    }


    $.ajax({
        type: 'POST',
        url: '/User/DeactivateUser/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
        headers: {
            User: localStorage.getItem("user"),
            Authorization: "bearer " + localStorage.getItem("token")
        },
    }).done(function (data) {
        self.result("Done!");
    })
// .fail(showError);
});
