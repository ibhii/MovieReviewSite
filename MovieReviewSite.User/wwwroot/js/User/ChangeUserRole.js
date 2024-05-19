const submitButton = document.getElementById("changeRole");
submitButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const roleCode = document.getElementById("userRoleCode").value;
    const userId = document.getElementById("userId").value;
    const modifierRoleCode = localStorage.getItem('roleCode')


    const dto = {
        roleCode : roleCode,
        userId : userId,
        modifierRoleCode : modifierRoleCode
    }

    $.ajax({
        type: 'POST',
        url: '/User/ChangeUserRole',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify(dto),
        headers: {
            User: localStorage.getItem("user"),
            Authorization: "bearer " + localStorage.getItem("token")
        }
    }).done(function (data) {
        self.result("Done!");}
    
    )});
