const deleteButton = document.getElementById("deleteCrew");
deleteButton.addEventListener("submit", function(event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];

    //getting authorizing token
    // const token = localStorage.getItem('accessToken');
    // if (!token) {
    //     console.error("Missing access token for authorized request");
    //     return; // Handle missing token scenario
    // }
    
$.ajax({
    type: 'POST',
    url: '/Crew/DeleteCrew/' + id,
    contentType: 'application/json; charset=utf-8',
   
    // headers: {
    //     'Authorization': `Bearer ${token}`
    // }
}).done(function (data) {
    self.result("Done!");}
)});
