import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SessionService } from '../session.service';

@Injectable({
  providedIn: 'root'
})
export class RecipeBookService {

  constructor(
    private http: HttpClient
    ) { }

  myRecipes(): Observable<any> {
    return this.http.get(
      environment.LETS_EAT_API.RECIPE_BOOK.MY_RECIPES
    );
  }
}
