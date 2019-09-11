const production = false;

const BASE_API = `https://localhost:5001/api/v1`;

const LETS_EAT_API = {
  AUTH: {
    LOGIN: `${BASE_API}/account/Login`,
    LOGOUT: `${BASE_API}/account/LogOff`,
    REGISTER: `${BASE_API}/account/Register`,
    CHANGE_PASSWORD: `${BASE_API}/account/ChangePassword`,
    CHANGE_FAMILY: `${BASE_API}/account/ChangeFamily`,
    DELETE_INVITE: `${BASE_API}/account/DeleteInvite`
  },
  ADMIN: {

  },
  IMAGES: {

  },
  RECIPE_BOOK: {
    MY_RECIPES: `${BASE_API}/RecipeBook/MyRecipes`
  },
  RECIPE: {
    
  }
};

const SESSION_KEYS = {
  USER: 'current_user',
  API_SESSION_KEY: '.AspNetCore.Session'
};

export const BaseEnvironment = {
  production,
  BASE_API,
  LETS_EAT_API,
  SESSION_KEYS
};