const deleteButton = document.getElementById("deleteCrew");
deleteButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];
    const userId = document.getElementById("userId").value;
    
$.ajax({
    type: 'POST',
    url: '/Crew/DeleteCrew/' + id,
    contentType: 'application/json; charset=utf-8',
    data: JSON.stringify(userId),
}).done(function (data) {
    self.result("Done!");}
    
)
    alert("Crew Deleted!")
    window.history.back();
});
