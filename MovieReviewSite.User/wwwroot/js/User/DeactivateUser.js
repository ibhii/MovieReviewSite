const deleteButton = document.getElementById("deactivateUser");
deleteButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    
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
