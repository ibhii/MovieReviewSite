const searchButton = document.getElementById("searchRequest");
const searchTermInput = document.getElementById("searchTerm");
const tableBody = document.getElementById("tableData");

searchButton.addEventListener("submit", function() {
    
    const search = searchTermInput.value.trim() || "";

    const dto = {
        search: search,
    }
    fetch("/Movie/GetMoviesList" ,{ // Assuming an API endpoint for adding movies
        method: "GET",
            headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(dto)
    })
        .then(response => response.json())
        .then(data => { // Update table content with search results (data)
            tableBody.innerHTML = ""; // Clear existing rows before adding new ones
            for (const item of data) {
                const tableRow = document.createElement("tr");
                const nameCell = document.createElement("td");
                nameCell.innerText = item.Name;
                const durationCell = document.createElement("td");
                durationCell.innerText = item.Duration;
                const ratingCell = document.createElement("td");
                ratingCell.innerText = item.Rating;
                const releaseDateCell = document.createElement("td");
                releaseDateCell.innerText = item.ReleaseDate; // Assuming ReleaseDate is a string
                const ageRateCell = document.createElement("td");
                ageRateCell.innerText = item.AgeRate;

                tableRow.appendChild(nameCell);
                tableRow.appendChild(durationCell);
                tableRow.appendChild(ratingCell);
                tableRow.appendChild(releaseDateCell);
                tableRow.appendChild(ageRateCell);

                tableBody.appendChild(tableRow);
            }
        })
        .catch(error => {
            // Handle errors (e.g., display an error message)
            console.error("Error fetching data:", error);
        });
});
