const searchForm = document.querySelector('form.search-form');
const searchInput = document.querySelector('input[type=text]');
const searchResultsDiv = document.querySelector('div.search-results')
const familyId = document.querySelector('#family-id').value;
const invitedById = document.querySelector('#invited-by-id').value;
const apiUrl = `${window.location.origin}/api/`;

searchForm.addEventListener('submit', e => {
    e.preventDefault();
    let searchTerm = searchInput.value;

    getResults(searchTerm);
});

function getResults(searchTerm) {
    fetch(apiUrl + 'SearchForMemberToAdd?email=' + searchTerm)
        .then(response => {
            response.json()
                .then(data => redrawResults(data))
        });
}

function inviteToFamily(userId, btn) {
    const url = `${apiUrl}InviteUserToFamily?userId=${userId}&familyId=${familyId}&invited_by=${invitedById}`;

    fetch(url)
    .then(response => {
        if (response.ok) {
            btn.innerText = 'Invite Sent!';
            btn.classList.disable = true;
        } else {
            alert('Something went wrong, please try that again');
        }
    });
}

function redrawResults(data) {
    searchResultsDiv.innerHTML = '';

    data.forEach(user => {
        const container = document.createElement('div');
        container.classList.add('user');

        const name = document.createElement('h3');
        name.innerText = user.displayName;
        container.appendChild(name);

        const addToFamily = document.createElement('button');
        addToFamily.className = 'btn btn-primary invite';
        addToFamily.innerText = 'Invite To Family';
        container.appendChild(addToFamily);

        const userId = document.createElement('input');
        userId.type = 'hidden';
        userId.value = user.id;
        container.appendChild(userId);

        searchResultsDiv.appendChild(container);
    });

    document.querySelectorAll('button.invite').forEach(btn => {
        btn.addEventListener('click', e => {
            const userId = btn.parentElement.children[2].value;
            inviteToFamily(userId, btn);
        });
    });
}
