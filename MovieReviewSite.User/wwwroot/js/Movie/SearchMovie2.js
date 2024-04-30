const searchButton = document.getElementById("searchButton");
const searchTermInput = document.getElementById("searchTerm");
const tableBody = document.getElementById("tableData");

searchButton.addEventListener("submit", function() {
    const search = searchTermInput.value;

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
                const descriptionCell = document.createElement("td");
                descriptionCell.innerText = item.Description;

                tableRow.appendChild(nameCell);
                tableRow.appendChild(descriptionCell);

                tableBody.appendChild(tableRow);
            }
        })
        .catch(error => {
            // Handle errors
        });
});
