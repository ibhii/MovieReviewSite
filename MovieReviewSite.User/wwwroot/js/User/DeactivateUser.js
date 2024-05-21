const deleteButton = document.getElementById("deactivateUser");
deleteButton.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    
    const id = window.location.pathname.split('/')[3];

    $.ajax({
        type: 'POST',
        url: '/User/DeactivateUser/' + id,
        contentType: 'application/json; charset=utf-8',
    }).done(function (data) {
        self.result("Done!");
    })
// .fail(showError);
});
