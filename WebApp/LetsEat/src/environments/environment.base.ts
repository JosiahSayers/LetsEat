export const BaseEnvironment = {
  production: false,
  
  SESSION_KEYS: {
    ACCESS_TOKEN: 'accessToken',
    USER: 'user'
  },

  API: {
    BASE_URL: 'https://localhost:5001/api/v1/',
    ACCOUNT: {
      LOGIN: `${this.BaseEnvironment.API.BASE_URL}/account/login`,
      LOGOFF: `${this.BaseEnvironment.API.BASE_URL}/account/loggoff`,
      REGISTER: `${this.BaseEnvironment.API.BASE_URL}/account/register`,
      CHANGE_PASSWORD: `${this.BaseEnvironment.API.BASE_URL}/account/changepassword`
    },
    RECIPE_BOOK: {
      MY_RECIPES: `${this.BaseEnvironment.API.BASE_URL}/recipebook/myrecipes`,
      FAMILY_RECIPES: `${this.BaseEnvironment.API.BASE_URL}/recipebook/familyrecipes`,
      SEARCH: (query: string) => `${this.BaseEnvironment.API.BASE_URL}/recipebook/search?query=${query}`
    }
  }
}
