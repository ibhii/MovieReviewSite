const SubmitButton1 = document.getElementById("watched");
SubmitButton1.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];
    
    const dto = {
        MovieId : id,
        UserId : localStorage.getItem("userId"),
        ModifierId : localStorage.getItem("userId")
    }


    $.ajax({
        type: 'POST',
        url: '/Movie/AddMovieToWatched',
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

const SubmitButton2 = document.getElementById("wantToWatch");
SubmitButton2.addEventListener("submit", function (event) {
    event.preventDefault(); // Prevent default form submission
    const id = window.location.pathname.split('/')[3];

    const dto = {
        MovieId : id,
        UserId : localStorage.getItem("userId"),
        ModifierId : localStorage.getItem("userId")
    }


    $.ajax({
        type: 'POST',
        url: '/Movie/AddMovieToWantToWatch',
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

