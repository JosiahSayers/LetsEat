const ingredientsDiv = document.getElementById('ingredients');
const stepsDiv = document.getElementById('steps');
const submitButton = document.querySelector('#submit');
const form = document.querySelector('form');
let newestIngredientInput = document.querySelector('div#ingredients').children[0].children[0];
const addIngredientButton = document.querySelector('#addIngredient');
let newestStepInput = document.querySelector('div#steps').children[0].children[1];
const addStepButton = document.querySelector('#addStep');
const apiUrl = `${window.location.protocol}//${window.location.host}/api/Recipe`;

console.log(apiUrl)

submitButton.addEventListener('click', e => {
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
    newestIngredientInput.focus();
}

function addStep() {
    const newFormElement = document.createElement('div');
    newFormElement.className = 'form-group ingredient-step-group';
    newFormElement.innerHTML = `<span class="step-counter">${stepsDiv.querySelectorAll('input.step').length + 1}.</span><input type="text" class="form-control step" placeholder="Preheat the oven to 350 degrees"> <span class="oi oi-circle-x"></span>`;
    stepsDiv.appendChild(newFormElement);

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
    if (verifyData(recipe)) {
        fetch(apiUrl, {
            method: 'POST',
            cache: 'no-cache',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(recipe),
        }).then(res => {
            res.json().then(data => {
                if (data.id > 0) {
                    window.location.href = `${window.location.protocol}//${window.location.host}/RecipeBook/Recipe?id=${data.id}`;
                } else {
                    alert('Something went wrong on our end, please try again');
                }
            })
        })
    }
}

function verifyData(recipe) {
    let output = true;

    if (!recipe.Name) {
        alert('You must provide a NAME for your recipe');
        output = false;
    } else if (!recipe.Description) {
        alert('You must provide a DESCRIPTION for your recipe');
        output = false;
    } else if (!recipe.Source) {
        alert('You must provide a SOURCE for your recipe');
        output = false;
    } else if (!recipe.PrepMinutes) {
        alert('You must provide a PREP TIME for your recipe');
        output = false;
    } else if (!recipe.CookMinutes) {
        alert('You must provide a COOK TIME for your recipe');
        output = false;
    } else if (recipe.Ingredients.length < 1) {
        alert('You must provide at least 1 INGREDIENT for your recipe');
        output = false;
    } else if (recipe.Steps.length < 1) {
        alert('You must provide at least 1 STEP for your recipe');
        output = false;
    }

    return output;
}

function recountSteps() {
    const counters = stepsDiv.querySelectorAll('span.step-counter');
    let count = 1;

    counters.forEach(counter => {
        counter.innerText = count++;
    })
}