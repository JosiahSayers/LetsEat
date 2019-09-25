import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/shared/services/http/http.service';
import { environment } from 'src/environments/environment';
import { Observable, of } from 'rxjs';
import { RecipeBook } from 'src/app/shared/models/recipe-book.model';
import { tap, findIndex } from 'rxjs/operators';
import { Recipe } from 'src/app/shared/models/recipe.model';
import { SessionService } from 'src/app/shared/services/session/session.service';
import { CacheService } from 'src/app/shared/services/cache/cache.service';

@Injectable({
  providedIn: 'root'
})
export class RecipeBookService {

  constructor(
    private http: HttpService,
    private session: SessionService,
    private cache: CacheService
  ) { }

  getMyRecipes(): Observable<RecipeBook> {
    let myRecipes = new Observable<RecipeBook>(recipeBook => {
      if (this.cache.myRecipes) {
        recipeBook.next(this.cache.myRecipes);
      }

      if (!this.cache.areMyRecipesValid) {
        this.refreshRecipes(environment.API.RECIPE_BOOK.MY_RECIPES).subscribe(refreshedRecipeBook => {
          this.cache.myRecipes = refreshedRecipeBook;
          recipeBook.next(refreshedRecipeBook);
        });
      }
    });

    return myRecipes;
  }

  getFamilyRecipes(): Observable<RecipeBook> {
    let familyRecipes = new Observable<RecipeBook>(recipeBook => {
      if (this.cache.familyRecipes) {
        recipeBook.next(this.cache.familyRecipes);
      }

      if (!this.cache.areFamilyRecipesValid) {
        this.refreshRecipes(environment.API.RECIPE_BOOK.FAMILY_RECIPES).subscribe(refreshedRecipeBook => {
          this.cache.familyRecipes = refreshedRecipeBook;
          recipeBook.next(refreshedRecipeBook);
        });
      }
    });

    return familyRecipes;
  }

  getRecipe(recipeId: number): Recipe {
    let recipe = this.trySearchingMyRecipes(recipeId);
    return recipe;
  }

  private trySearchingMyRecipes(id: number) {
    if (this.session.myRecipes) {
      return this.findRecipeById(this.session.myRecipes.recipes, id);
    } else {
      return this.trySearchingFamilyRecipes(id);
    }
  }

  private trySearchingFamilyRecipes(id: number) {
    if (this.session.familyRecipes) {
      return this.findRecipeById(this.session.familyRecipes.recipes, id);
    } else {
      return null;
    }
  }

  private findRecipeById(recipes: Recipe[], id: number): Recipe {
    return recipes.find(recipe => recipe.id === id);
  }

  private refreshRecipes(url: string): Observable<RecipeBook> {
    return this.http.get({
      url,
      sendWithAuth: true
    });
  }
}
