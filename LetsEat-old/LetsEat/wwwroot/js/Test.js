const input = document.querySelector('input');
const button = document.querySelector('div.btn');

const apiUrl = `${window.location.protocol}//${window.location.host}/api/Image`;

button.addEventListener('click', e => {
    if (!input.files[0].type.includes('image')) {
        alert('file must be an image');
        input.value = input.defaultValue;
    } else {
        upload();
    }
});

function upload() {
    let formData = new FormData();

    console.log(input.files[0]);

    formData.append('File', input.files[0]);
    formData.append('RecipeId', '1');

    fetch(apiUrl, {
        method: 'POST',
        body: formData
    })
}