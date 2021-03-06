﻿const ingredientsDiv = document.getElementById('ingredients').children[1];
const stepsDiv = document.getElementById('steps').children[1];
const submitButton = document.querySelector('#submit');
const form = document.querySelector('form');
let newestIngredientInput = ingredientsDiv.children[0].children[0];
const addIngredientButton = document.querySelector('#addIngredient');
let newestStepInput = stepsDiv.children[0].children[1];
const addStepButton = document.querySelector('#addStep');
const spinner = document.querySelector('#spinner');
const imageInput = document.querySelector('#Image-Upload');

const recipeApiUrl = `${window.location.protocol}//${window.location.host}/api/Recipe`;
const imageApiUrl = `${window.location.protocol}//${window.location.host}/api/Image`;

console.log()

submitButton.addEventListener('click', e => {
    e.preventDefault();

    const newRecipe = {
        Name: document.querySelector('input#Name').value,
        Description: document.querySelector('#description').value,
        PrepMinutes: parseInt(document.querySelector('#PrepMinutes').value),
        CookMinutes: parseInt(document.querySelector('#CookMinutes').value),
        Source: document.querySelector('#Source').value,
        UserWhoAdded: { Id: parseInt(document.querySelector('#UserWhoAdded').value) },
        Steps: getSteps(),
        Ingredients: getIngredients()
    };

    sendRecipe(newRecipe);
});

addIngredientButton.addEventListener('click', e => {
    if (newestIngredientInput.value.trim() != '') {
        addIngredient();
    }
});

addStepButton.addEventListener('click', e => {
    if (newestStepInput.value.trim() != '') {
        addStep();
    }
});

document.querySelector('#PrepMinutes').addEventListener('input', e => {
    const field = document.querySelector('#PrepMinutes');

    verifyNumberInput(field, e);
});

document.querySelector('#CookMinutes').addEventListener('input', e => {
    const field = document.querySelector('#CookMinutes');

    verifyNumberInput(field, e);
});

imageInput.addEventListener('change', e => {
    imageInput.nextElementSibling.innerText = imageInput.files[0].name;
});

function verifyNumberInput(field, e) {
    if (e.data === '.') {
        pop(field);
    }

    if (e.data === '-') {
        pop(field);
    }

    if (Number(field.value) > 999) {
        pop(field);
    }

    if (Number(field.value) < 0) {
        field.value = 0;
    }
}

function pop(element) {
    element.value = element.value.substring(0, element.value.length - 1);
}

function addIngredient() {
    const newFormElement = document.createElement('div');
    newFormElement.className = 'form-group ingredient-group';
    newFormElement.innerHTML = '<input type="text" class="form-control ingredient" placeholder="1/2 cup of milk"> <span class="oi oi-circle-x"></span>';
    ingredientsDiv.appendChild(newFormElement);


    newFormElement.querySelector('span').addEventListener('click', e => {
        ingredientsDiv.removeChild(e.path[1]);
        newestIngredientInput = ingredientsDiv.children[ingredientsDiv.children.length - 1].children[0];
    });

    newestIngredientInput = ingredientsDiv.children[ingredientsDiv.children.length - 1].children[0];
    newestIngredientInput.focus();
}

function addStep() {
    const newFormElement = document.createElement('div');
    newFormElement.className = 'input-group mb-2';
    newFormElement.innerHTML = `<div class="input-group-prepend"><div class="input-group-text">${stepsDiv.querySelectorAll('input.step').length + 1}.</div></div><input type="text" class="form-control step" id="inlineFormInputGroup" placeholder="Preheat the oven to 350 degrees"> <span class="oi oi-circle-x"></span>`;
    stepsDiv.appendChild(newFormElement);

    //<div class="input-group mb-2">
    //    <div class="input-group-prepend">
    //        <div class="input-group-text">1.</div>
    //    </div>
    //    <input type="text" class="form-control" id="inlineFormInputGroup" placeholder="Preheat the oven to 350 degrees">
    //</div>

    newFormElement.querySelector('span.oi').addEventListener('click', e => {
        stepsDiv.removeChild(e.path[1]);
        newestStepInput = stepsDiv.children[stepsDiv.children.length - 1].children[1];
        recountSteps();
    });

    newestStepInput = stepsDiv.children[stepsDiv.children.length - 1].children[1];
    newestStepInput.focus();
}

function getSteps() {
    let steps = [];
    let stepNodes = stepsDiv.querySelectorAll('input.step');
    stepNodes.forEach(node => steps.push(node.value));

    if (steps[steps.length - 1].trim() === '') {
        steps.pop();
    }

    return steps;
}

function getIngredients() {
    let ingredients = [];
    let ingNodes = ingredientsDiv.querySelectorAll('input.ingredient');
    ingNodes.forEach(node => ingredients.push(node.value));

    if (ingredients[ingredients.length - 1].trim() === '') {
        ingredients.pop();
    }

    return ingredients;
}

function sendRecipe(recipe) {
    const check = verifyData(recipe);

    if (check.ok) {
        form.style.display = 'none';
        spinner.style.display = 'flex';

        fetch(recipeApiUrl, {
            method: 'POST',
            cache: 'no-cache',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(recipe),
        }).then(res => {
            res.json().then(data => {
                if (data.id > 0) {
                    console.log(data);

                    let formData = new FormData();

                    formData.append('File', imageInput.files[0]);
                    formData.append('RecipeId', data.id);

                    fetch(imageApiUrl, {
                        method: 'POST',
                        body: formData
                    }).then(imageRes => {
                        if (imageRes.ok) {
                            window.location.href = `${window.location.protocol}//${window.location.host}/RecipeBook/Recipe?id=${data.id}`;
                        } else {
                            alert('Something went wrong when uploading your image, please verify that you are uploadin the correct item and try again.');
                        }
                    });
                } else {
                    alert('Something went wrong on our end, please try again');
                    form.style.display = 'block';
                }
            });
        });
    } else {
        displayFieldErrors(check)
    }
}

function verifyData(recipe) {
    let fieldCheck = {
        name: { alert: 'You must provide a NAME for your recipe', status: true },
        description: { alert: 'You must provide a DESCRIPTION for your recipe', status: true },
        source: { alert: 'You must provide a SOURCE for your recipe', status: true },
        prepMinutes: { alert: 'You must provide a PREP TIME for your recipe', status: true },
        cookMinutes: { alert: 'You must provide a COOK TIME for your recipe', status: true },
        ingredients: { alert: 'You must provide at least 1 INGREDIENT for your recipe', status: true },
        steps: { alert: 'You must provide at least 1 STEP for your recipe', status: true },
        ok: true
    };


    if (!recipe.Name) {
        fieldCheck.name.status = false;
        fieldCheck.ok = false;
    }
    if (!recipe.Description) {
        fieldCheck.description.status = false;
        fieldCheck.ok = false;
    }
    if (!recipe.Source) {
        fieldCheck.source.status = false;
        fieldCheck.ok = false;
    }
    if (!recipe.PrepMinutes) {
        fieldCheck.prepMinutes.status = false;
        fieldCheck.ok = false;
    }
    if (!recipe.CookMinutes) {
        fieldCheck.cookMinutes.status = false;
        fieldCheck.ok = false;
    }
    if (recipe.Ingredients.length < 1) {
        fieldCheck.ingredients.status = false;
        fieldCheck.ok = false;
    }
    if (recipe.Steps.length < 1) {
        fieldCheck.steps.status = false;
        fieldCheck.ok = false;
    }

    return fieldCheck;
}

function displayFieldErrors(check) {
    let alertMessage;

    if (check.name.status) {
        document.querySelector('#Name').previousElementSibling.style.color = 'black';
    } else {
        document.querySelector('#Name').previousElementSibling.style.color = 'red';
    }

    if (check.description.status) {
        document.querySelector('#description').previousElementSibling.style.color = 'black';
    } else {
        document.querySelector('#description').previousElementSibling.style.color = 'red';
    }

    if (check.source.status) {
        document.querySelector('#Source').previousElementSibling.style.color = 'black';
    } else {
        document.querySelector('#Source').previousElementSibling.style.color = 'red';
    }

    if (check.prepMinutes.status) {
        document.querySelector('#PrepMinutes').previousElementSibling.style.color = 'black';
    } else {
        document.querySelector('#PrepMinutes').previousElementSibling.style.color = 'red';
    }

    if (check.cookMinutes.status) {
        document.querySelector('#CookMinutes').previousElementSibling.style.color = 'black';
    } else {
        document.querySelector('#CookMinutes').previousElementSibling.style.color = 'red';
    }

    if (check.ingredients.status) {
        document.querySelector('#ing-id').style.color = 'black';
    } else {
        document.querySelector('#ing-id').style.color = 'red';
    }

    if (check.steps.status) {
        document.querySelector('#step-id').style.color = 'black';
    } else {
        document.querySelector('#step-id').style.color = 'red';
    }
}

function recountSteps() {
    const counters = stepsDiv.querySelectorAll('.step-counter');
    let count = 1;

    counters.forEach(counter => {
        counter.innerText = count++;
    })
}