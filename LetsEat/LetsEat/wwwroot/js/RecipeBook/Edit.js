const deleteButton = document.querySelector('#delete');
const recipeId = document.querySelector('#recipe-id').value;

const apiUrl = `${window.location.protocol}//${window.location.host}/api/Recipe/${recipeId}`;


deleteButton.addEventListener('click', () => {
    sendDeleteRequest();
});

function sendDeleteRequest() {
    fetch(apiUrl, {
        method: 'DELETE'
    }).then(res => {
        if (res.ok) {
            window.location.href = `${window.location.protocol}//${window.location.host}/RecipeBook`;
        } else {
            alert('Uh-oh! Something went wrong on our end. Please try again');
        }
    })
}