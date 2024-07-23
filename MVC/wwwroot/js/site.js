// DOMContentLoaded Event: Ensures the script runs after the DOM is fully loaded.
document.addEventListener('DOMContentLoaded', function () {
    const dropdownButton = document.getElementById('dropdownMenuButton');
    const dropdownMenu = document.querySelector('.dropdown-menu');
    const homeLink = document.getElementById('homeLink');
    const homeUrl = document.querySelector('script[src*="site.js"]').getAttribute('data-home-url');

    // Toggles the dropdown menu visibility when the button is clicked
    dropdownButton.addEventListener('click', function () {
        dropdownMenu.classList.toggle('show');
    });

    // Updates the dropdown button text and redirects the user to the home page with the selected genre as a query parameter.
    document.querySelectorAll('.dropdown-item').forEach(item => {
        item.addEventListener('click', function (event) {
            event.preventDefault();
            const selectedGenre = this.getAttribute('data-genre');
            // Update the button text
            dropdownButton.innerText = this.innerText;
            // Redirect to URL with selected genre
            window.location.href = `${homeUrl}${selectedGenre ? '?genre=' + encodeURIComponent(selectedGenre) : ''}`;
        });
    });

    // Redirect to home page when "Movie Shop" title is clicked
    homeLink.addEventListener('click', (event) => {
        event.preventDefault();
        window.location.href = homeUrl;
    });

    // Close dropdown if clicking outside
    window.addEventListener('click', function (event) {
        if (!event.target.matches('#dropdownMenuButton')) {
            if (dropdownMenu.classList.contains('show')) {
                dropdownMenu.classList.remove('show');
            }
        }
    });
});
