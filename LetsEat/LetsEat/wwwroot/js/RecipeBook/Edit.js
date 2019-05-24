const deleteButton = document.querySelector('#delete');
const saveButton = document.querySelector('#save');

const addIngredientButton = document.querySelector('#addIngredient');
const ingredientsDiv = document.getElementById('ingredients').children[1];
let newestIngredientInput = ingredientsDiv.children[0].children[0];

const addStepButton = document.querySelector('#addStep');
const stepsDiv = document.getElementById('steps').children[1];
let newestStepInput = stepsDiv.children[0].children[1];




// Recipe Elements
const recipeId = document.querySelector('#recipe-id').value;
const nameElement = document.getElementById('Name');
const descriptionElement = document.getElementById('Description');
const prepMinutesElement = document.getElementById('PrepMinutes');
const cookMinutesElement = document.getElementById('CookMinutes');
let ingredientElements = document.querySelectorAll('input.ingredient');
let stepElements = document.querySelectorAll('input.step');
let imageElements = document.querySelectorAll('img.image');

const recipeApiUrl = `${window.location.protocol}//${window.location.host}/api/Recipe/${recipeId}`;

// api requests
function sendUpdatedRecipe() {
    fetch(recipeApiUrl, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(buildFormData())
    })
}

function sendDeleteRequest() {
    fetch(recipeApiUrl, {
        method: 'DELETE'
    }).then(res => {
        if (res.ok) {
            window.location.href = `${window.location.protocol}//${window.location.host}/RecipeBook`;
        } else {
            alert('Uh-oh! Something went wrong on our end. Please try again');
        }
    })
}

// Logic for DOM Manipulation

document.addEventListener('load', addDeleteButtons());

function addDeleteButtons() {
    for (let i = 1; i < ingredientElements.length; i++) {
        const deleteElement = document.createElement('span');
        deleteElement.className = 'oi oi-circle-x';

        ingredientElements[i].insertAdjacentElement('afterend', deleteElement);

        deleteElement.addEventListener('click', e => {
            ingredientsDiv.removeChild(e.path[1]);
            newestIngredientInput = ingredientsDiv.children[ingredientsDiv.children.length - 1].children[0];
            console.log(ingredientsDiv)
        });
    }

    for (let i = 1; i < stepElements.length; i++) {
        const deleteElement = document.createElement('span');
        deleteElement.className = 'oi oi-circle-x';

        stepElements[i].insertAdjacentElement('afterend', deleteElement);

        deleteElement.addEventListener('click', e => {
            stepsDiv.removeChild(e.path[1]);
            newestStepInput = stepsDiv.children[stepsDiv.children.length - 1].children[1];
            recountSteps();
        });
    }
}

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

function addIngredient() {
    const newFormElement = document.createElement('div');
    newFormElement.className = 'form-group ingredient-group';
    newFormElement.innerHTML = '<input type="text" class="form-control ingredient" placeholder="1/2 cup of milk"> <span class="oi oi-circle-x"></span>';
    ingredientsDiv.appendChild(newFormElement);


    newFormElement.querySelector('span').addEventListener('click', e => {
        ingredientsDiv.removeChild(e.path[1]);
        newestIngredientInput = ingredientsDiv.children[ingredientsDiv.children.length - 1].children[0];
        console.log(ingredientsDiv)

    });

    newestIngredientInput = ingredientsDiv.children[ingredientsDiv.children.length - 1].children[0];
    newestIngredientInput.focus();
    ingredientElements = document.querySelectorAll('input.ingredient');
}

function addStep() {
    const newFormElement = document.createElement('div');
    newFormElement.className = 'input-group mb-2';
    newFormElement.innerHTML = `<div class="input-group-prepend"><div class="input-group-text step-counter">${stepsDiv.querySelectorAll('input.step').length + 1}.</div></div><input type="text" class="form-control step" id="inlineFormInputGroup" placeholder="Preheat the oven to 350 degrees"> <span class="oi oi-circle-x"></span>`;
    stepsDiv.appendChild(newFormElement);

    newFormElement.querySelector('span.oi').addEventListener('click', e => {
        stepsDiv.removeChild(e.path[1]);
        newestStepInput = stepsDiv.children[stepsDiv.children.length - 1].children[1];
        recountSteps();
    });

    newestStepInput = stepsDiv.children[stepsDiv.children.length - 1].children[1];
    newestStepInput.focus();
}

function recountSteps() {
    const counters = document.querySelectorAll('.step-counter');
    let count = 1;

    counters.forEach(counter => {
        counter.innerText = count++;
    })
}

function pop(element) {
    element.value = element.value.substring(0, element.value.length - 1);
}

// Logic for recipe data

function buildFormData() {
    return {
        ID: recipeId,
        Name: nameElement.value,
        Description: descriptionElement.value,
        PrepMinutes: prepMinutesElement.value,
        CookMinutes: cookMinutesElement.value,
        Steps: getSteps(),
        Ingredients: getIngredients(),
        ImageLocations: getImageLocations()
    };
}

function getSteps() {
    let steps = [];
    stepElements.forEach(node => steps.push(node.value));

    if (steps[steps.length - 1].trim() === '') {
        steps.pop();
    }

    return steps;
}

function getIngredients() {
    let ingredients = [];
    ingredientElements.forEach(node => ingredients.push(node.value));

    if (ingredients[ingredients.length - 1].trim() === '') {
        ingredients.pop();
    }

    return ingredients;
}

function getImageLocations() {
    let imageLocations = [];
    imageElements.forEach(img => imageLocations.push(img.src));

    return imageLocations;
}


// Event Listeners

deleteButton.addEventListener('click', () => {
    sendDeleteRequest();
});

saveButton.addEventListener('click', () => sendUpdatedRecipe());
