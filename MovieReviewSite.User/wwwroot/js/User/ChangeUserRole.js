﻿const submitButton = document.getElementById("changeRole");
submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const roleCode = document.getElementById("userRoleCode").value;
    const userId = document.getElementById("userId").value;


    const dto = {
        roleCode : roleCode,
        userId : userId,
    }

    $.ajax({
        type: 'POST',
        url: '/User/ChangeUserRole',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
    }).done(function (data) {
        self.result("Done!");}
    )
    alert("role changed")
    window.location.reload()
});
