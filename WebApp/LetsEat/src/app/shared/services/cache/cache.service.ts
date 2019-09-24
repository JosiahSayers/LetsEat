import { Injectable } from '@angular/core';
import { SessionService } from '../session/session.service';
import { RecipeBook } from '../../models/recipe-book.model';
import { CACHE_SESSION_KEYS } from './cache-validation.constants';
import { RecipeComponent } from 'src/app/recipe-book/components/recipe/recipe.component';

@Injectable({
  providedIn: 'root'
})
export class CacheService {

  constructor(private session: SessionService) { }

  set myRecipes(recipeBook: RecipeBook) {
    this.session.myRecipes = recipeBook;
    this.session.validateCache(CACHE_SESSION_KEYS.MY_RECIPES);
  }

  get myRecipes(): RecipeBook {
    return this.session.myRecipes;
  }

  get areMyRecipesValid(): boolean {
    return this.session.isCacheValid(CACHE_SESSION_KEYS.MY_RECIPES);
  }

  set familyRecipes(recipeBook: RecipeBook) {
    this.session.familyRecipes = recipeBook;
    this.session.validateCache(CACHE_SESSION_KEYS.FAMILY_RECIPES);
  }

  get familyRecipes(): RecipeBook {
    return this.session.familyRecipes;
  }

  get areFamilyRecipesValid(): boolean {
    return this.session.isCacheValid(CACHE_SESSION_KEYS.FAMILY_RECIPES);
  }

  invalidateCache(cacheConstant: CACHE_SESSION_KEYS) {
    this.session.invalidateCache(cacheConstant);
  }

}
