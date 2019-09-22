import { Injectable } from '@angular/core';
import { HttpService } from 'src/app/shared/services/http/http.service';
import { environment } from 'src/environments/environment';
import { Observable, of } from 'rxjs';
import { RecipeBook } from 'src/app/shared/models/recipe-book.model';
import { tap } from 'rxjs/operators';
import { Recipe } from 'src/app/shared/models/recipe.model';
import { SessionService } from 'src/app/shared/services/session/session.service';

@Injectable({
  providedIn: 'root'
})
export class RecipeBookService {

  constructor(
    private http: HttpService,
    private session: SessionService
  ) { }

  getMyRecipes(): Observable<RecipeBook> {
    let myRecipes = new Observable<RecipeBook>(recipeBook => {
      if (this.session.myRecipes) {
        recipeBook.next(this.session.myRecipes)
      }

      this.refreshMyRecipes().subscribe(refreshedRecipeBook => {
        recipeBook.next(refreshedRecipeBook);
      });
    });

    return myRecipes;
  }

  getRecipe(recipeId: number): Recipe {
    let recipe = this.session.myRecipes.recipes.filter(recipe => (
      recipe.id === recipeId
      ))[0];
    return recipe;
  }

  private refreshMyRecipes(): Observable<RecipeBook> {
    return this.http.get({
      url: environment.API.RECIPE_BOOK.MY_RECIPES,
      sendWithAuth: true
    }).pipe(
      tap(recipeBook => this.session.myRecipes = recipeBook)
    );
  }
}
