export const BaseEnvironment = {
  production: false,

  SESSION_KEYS: {
    ACCESS_TOKEN: 'accessToken',
    USER: 'user'
  },

  API_BASE_URL: 'https://localhost:5001/api/v1/',

  API: {
    ACCOUNT: {
      LOGIN: `https://localhost:5001/api/v1/account/login`,
      LOGOFF: `https://localhost:5001/api/v1/account/logoff`,
      REGISTER: `https://localhost:5001/api/v1/account/register`,
      CHANGE_PASSWORD: `https://localhost:5001/api/v1/account/changepassword`,
      IS_EMAIL_AVAILABLE: (email: string) => `https://localhost:5001/api/v1/account/isemailavailable?email=${email}`
    },
    RECIPE_BOOK: {
      MY_RECIPES: `https://localhost:5001/api/v1/recipebook/myrecipes`,
      FAMILY_RECIPES: `https://localhost:5001/api/v1/recipebook/familyrecipes`,
      SEARCH: (query: string) => `https://localhost:5001/api/v1/recipebook/search?query=${query}`
    }
  },
  
  NAVBAR_LINKS: {
    UNAUTHENTICATED: [
      {
        text: 'Login',
        route: '/login'
      }
    ],
    AUTHENTICATED: [
      {
        text: 'My Recipes',
        route: '/recipe-book/personal'
      },
      {
        text: 'Family Recipes',
        route: '/recipe-book/family'
      }
    ]
  }
}
