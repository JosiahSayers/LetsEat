const ingredientsDiv = document.getElementById('ingredients');
const stepsDiv = document.getElementById('steps');
const submitButton = document.querySelector('input.btn-primary');
const form = document.querySelector('form');
let newestIngredientInput = document.querySelector('div#ingredients').children[0].children[0];
const addIngredientButton = document.querySelector('#addIngredient');
let newestStepInput = document.querySelector('div#steps').children[0].children[0];
const addStepButton = document.querySelector('#addStep');



form.addEventListener('submit', e => {
    e.preventDefault();

    const newRecipe = {
        Name: document.querySelector('input#Name').value,
        Description: document.querySelector('#description').value,
        PrepMinutes: parseInt(document.querySelector('#PrepMinutes').value),
        CookMinutes: parseInt(document.querySelector('#CookMinutes').value),
        Source: document.querySelector('#Source').value,
        UserWhoAdded: { Id: parseInt(document.querySelector('#UserWhoAdded').value)},
        Steps: getSteps(),
        Ingredients: getIngredients()
    };

    // Add logic to send new recipe to API endpoint
    sendRecipe(newRecipe);

    console.log(newRecipe);
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

function addIngredient() {
    const newFormElement = document.createElement('div');
    newFormElement.className = 'form-group ingredient-step-group';
    newFormElement.innerHTML = '<input type="text" class="form-control ingredient" placeholder="1/2 cup of milk"> <span class="oi oi-circle-x"></span>';
    ingredientsDiv.appendChild(newFormElement);

    newFormElement.querySelector('span').addEventListener('click', e => {
        ingredientsDiv.removeChild(e.path[1]);
        newestIngredientInput = ingredientsDiv.children[ingredientsDiv.children.length - 1].children[0];
    });

    newestIngredientInput = ingredientsDiv.children[ingredientsDiv.children.length - 1].children[0];
}

function addStep() {
    const newFormElement = document.createElement('div');
    newFormElement.className = 'form-group ingredient-step-group';
    newFormElement.innerHTML = '<input type="text" class="form-control step" placeholder="Preheat the oven to 350 degrees"> <span class="oi oi-circle-x"></span>';
    stepsDiv.appendChild(newFormElement);

    newFormElement.querySelector('span').addEventListener('click', e => {
        stepsDiv.removeChild(e.path[1]);
        newestStepInput = stepsDiv.children[stepsDiv.children.length - 1].children[0];
    });

    newestStepInput = stepsDiv.children[stepsDiv.children.length - 1].children[0];
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

}