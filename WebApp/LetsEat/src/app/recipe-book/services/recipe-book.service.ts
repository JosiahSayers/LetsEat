import { Injectable } from '@angular/core';
import { SessionService } from 'src/app/shared/services/session/session.service';
import { HttpService } from 'src/app/shared/services/http/http.service';
import { environment } from 'src/environments/environment';
import { Recipe } from 'src/app/shared/models/recipe.model';
import { Observable } from 'rxjs';
import { RecipeBook } from 'src/app/shared/models/recipe-book.model';

@Injectable({
  providedIn: 'root'
})
export class RecipeBookService {

  constructor(
    private http: HttpService
  ) { }

  myRecipes: Recipe[];

  getMyRecipes(): Observable<RecipeBook> {
    return this.http.get({
      url: environment.API.RECIPE_BOOK.MY_RECIPES,
      sendWithAuth: true
    });
  }
}
