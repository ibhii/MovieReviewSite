const deleteButton = document.getElementById("deleteCrew");
deleteButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];
    
    
$.ajax({
    type: 'POST',
    url: '/Crew/DeleteCrew/' + id,
    contentType: 'application/json; charset=utf-8',
    headers: {
        User: localStorage.getItem("user"),
        Authorization: "bearer " + localStorage.getItem("token")
    }
}).done(function (data) {
    self.result("Done!");}
)});
