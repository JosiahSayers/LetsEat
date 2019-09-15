import { Injectable } from '@angular/core';
import { SessionService } from 'src/app/shared/services/session/session.service';
import { HttpService } from 'src/app/shared/services/http/http.service';
import { environment } from 'src/environments/environment';
import { tap } from 'rxjs/operators';
import { Recipe } from 'src/app/shared/models/recipe.model';
import { of, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RecipeBookService {

  constructor(
    private session: SessionService,
    private http: HttpService
  ) { }

  myRecipes: Recipe[];

  getMyRecipes(): Observable<Recipe[]> {
    return this.http.get({
      url: environment.API.RECIPE_BOOK.MY_RECIPES,
      sendWithAuth: true
    });
  }
}
