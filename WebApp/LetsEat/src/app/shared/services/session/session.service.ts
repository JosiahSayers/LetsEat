import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../../models/user.model';
import { RecipeBook } from '../../models/recipe-book.model';
import { CACHE_SESSION_KEYS, CACHE_STATUS } from '../cache/cache-validation.constants';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor() { }

  get accessToken(): string {
    return sessionStorage.getItem(environment.SESSION_KEYS.ACCESS_TOKEN) || undefined;
  }

  set accessToken(token: string) {
    sessionStorage.setItem(environment.SESSION_KEYS.ACCESS_TOKEN, token);
  }

  get user(): User {
    let user;

    try {
      user = JSON.parse(sessionStorage.getItem(environment.SESSION_KEYS.USER));
    } catch {
      user = undefined;
    }

    return user;
  }

  set user(user: User) {
    sessionStorage.setItem(environment.SESSION_KEYS.USER, JSON.stringify(user));
  }

  get myRecipes(): RecipeBook {
    let recipeBook;

    try {
      recipeBook = JSON.parse(sessionStorage.getItem(environment.SESSION_KEYS.MY_RECIPES));
    } catch {
      recipeBook = undefined;
    }

    return recipeBook;
  }

  set myRecipes(recipeBook: RecipeBook) {
    sessionStorage.setItem(environment.SESSION_KEYS.MY_RECIPES, JSON.stringify(recipeBook));
  }

  get familyRecipes(): RecipeBook {
    let recipeBook;

    try {
      recipeBook = JSON.parse(sessionStorage.getItem(environment.SESSION_KEYS.FAMILY_RECIPES));
    } catch {
      recipeBook = undefined;
    }

    return recipeBook;
  }

  set familyRecipes(recipeBook: RecipeBook) {
    sessionStorage.setItem(environment.SESSION_KEYS.FAMILY_RECIPES, JSON.stringify(recipeBook));
  }

  validateCache(key: CACHE_SESSION_KEYS): void {
    sessionStorage.setItem(key, CACHE_STATUS.VALID);
  }

  invalidateCache(key: CACHE_SESSION_KEYS): void {
    sessionStorage.setItem(key, CACHE_STATUS.INVALID);
  }

  isCacheValid(key: CACHE_SESSION_KEYS): boolean {
    return sessionStorage.getItem(key) === CACHE_STATUS.VALID;
  }
}
