import { Injectable } from '@angular/core';
import { SessionService } from '../session/session.service';
import { RecipeBook } from '../../models/recipe-book.model';
import { CACHE_SESSION_KEYS } from './cache-validation.constants';
import { RecipeComponent } from 'src/app/recipe-book/components/recipe/recipe.component';
import { User } from '../../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class CacheService {

  constructor(private session: SessionService) { }

  // My Recipes
  set myRecipes(recipeBook: RecipeBook) {
    this.session.myRecipes = recipeBook;
    this.isValueValid(recipeBook) ? this.session.validateCache(CACHE_SESSION_KEYS.MY_RECIPES)
      : this.session.invalidateCache(CACHE_SESSION_KEYS.MY_RECIPES);
  }

  get myRecipes(): RecipeBook {
    return this.session.myRecipes;
  }

  get areMyRecipesValid(): boolean {
    return this.session.isCacheValid(CACHE_SESSION_KEYS.MY_RECIPES);
  }

  // Family Recipes
  set familyRecipes(recipeBook: RecipeBook) {
    this.session.familyRecipes = recipeBook;
    this.isValueValid(recipeBook) ? this.session.validateCache(CACHE_SESSION_KEYS.FAMILY_RECIPES)
      : this.session.invalidateCache(CACHE_SESSION_KEYS.FAMILY_RECIPES);
  }

  get familyRecipes(): RecipeBook {
    return this.session.familyRecipes;
  }

  get areFamilyRecipesValid(): boolean {
    return this.session.isCacheValid(CACHE_SESSION_KEYS.FAMILY_RECIPES);
  }

  // User
  set user(user: User) {
    this.session.user = user;
    this.isValueValid(user) ? this.session.validateCache(CACHE_SESSION_KEYS.USER)
      : this.session.invalidateCache(CACHE_SESSION_KEYS.USER);
  }

  get user(): User {
    return this.session.user;
  }

  get isUserValid(): boolean {
    return this.session.isCacheValid(CACHE_SESSION_KEYS.USER);
  }

  invalidateCache(cacheConstant: CACHE_SESSION_KEYS) {
    this.session.invalidateCache(cacheConstant);
  }

  private isValueValid(value: any): boolean {
    return value !== null && value !== undefined;
  }
}
