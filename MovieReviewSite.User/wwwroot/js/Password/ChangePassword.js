const submitButton = document.getElementById("submitForm"); //// Get the form by its ID
submitButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission

    const currentPassword = document.getElementById("CurrentPassword").value;
    const newPassword = document.getElementById("NewPassword").value;
    const repeatedPassword = document.getElementById("RepeatedPassword").value;
    const password = document.getElementById("Password").value;
    const modifierId = document.getElementById("modifierId").value;
    const id = window.location.pathname.split('/')[3];

    if(currentPassword === newPassword){
        alert("please do not enter your previous password as the new one!")
    }
    if(newPassword !== repeatedPassword){
        alert("please reenter your new password!")
    }
    if(currentPassword !== password){
        alert("please enter your current password carefully!")
    }

    const dto = {
        currentPassword: currentPassword,
        newPassword: newPassword,
        ModifierId: modifierId,
    };


    $.ajax({
        type: 'POST',
        url: '/Password/ChangePasswordByUserId/' + id,
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
    }).done(function (data) {
        self.result("Done!");
    })
});

function showForCurrentPassword() {
    const x = document.getElementById("CurrentPassword");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}

function showForNewPassword() {
    const x = document.getElementById("NewPassword");
    if (x.type === "password") {
        x.type = "text";
    } else {
        x.type = "password";
    }
}
