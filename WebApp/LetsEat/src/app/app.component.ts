import { Component, OnInit } from '@angular/core';
import { AuthService } from './shared/services/auth/auth.service';
import { LoginResponse } from './shared/models/login-response.model';
import { User } from './shared/models/user.model';
import { catchError, tap } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
import { RecipeBookService } from './recipe-book/services/recipe-book.service';
import { Recipe } from './shared/models/recipe.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {  
  title = 'Lets Eat!';
  canLoadApplication = false;
  user: User;

  constructor(
    private auth: AuthService,
    private recipeBook: RecipeBookService
  ) { }

  ngOnInit() {
    // this.login()
    // .subscribe((loginResponse: LoginResponse) => {
    //   if (loginResponse && loginResponse.accessToken) {
    //     this.canLoadApplication = true;
    //     console.log(loginResponse);
    //     this.getRecipes().subscribe(recipes => {
    //       console.log(recipes);
    //       this.auth.logoff().subscribe(res => console.log(res));
    //     });
    //   }
    // });
  }
}
