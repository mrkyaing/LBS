
function sayWelcome() {
    alert("Welcome to LMS System!!");
}
// Sample data for demonstration
const books = [
    { BookID: 1, Title: "Romeo Julier", Author: "William Shakespeare", Publisher: "Penguin Classics", Price: 10.00, CoverImagePath: "images/RomeoJuliet.jpg" },
    { BookID: 2, Title: "Hamlet", Author: "William Shakespeare", Publisher: "Oxford University Press", Price: 15.00, CoverImagePath: "images/hamlet.jpg" },
    { BookID: 3, Title: "Essential of programming", Author: "Jame C", Publisher: "Oxford University Press", Price: 15.00, CoverImagePath: "images/Eop.jpg" },
    // Add more books as needed
];
// Function to render books
function renderBooks() {
    const booksList = document.getElementById('books-list');
    books.forEach(book => {
        const bookCard = `
            <div class="col-md-4">
                <div class="card mb-4" onblur="sayWelcome()">
                    <img src="${book.CoverImagePath}" class="card-img-top" alt="${book.Title}">
                    <div class="card-body">
                        <h5 class="card-title">${book.Title}</h5>
                        <p class="card-text"><strong>Author:</strong> ${book.Author}</p>
                        <p class="card-text"><strong>Publisher:</strong> ${book.Publisher}</p>
                        <p class="card-text"><strong>Price:</strong> $${book.Price.toFixed(2)}</p>
                    </div>
                </div>
            </div>
        `;
        booksList.innerHTML += bookCard;
    });
}
// Call the function to render books on page load
document.addEventListener('DOMContentLoaded', renderBooks);
//# sourceMappingURL=home.js.map