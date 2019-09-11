import { Component, OnInit } from '@angular/core';
import { AuthApiService } from './shared/services/api/auth-api.service';
import { environment } from 'src/environments/environment';
import { AuthService } from './shared/services/auth/auth.service';
import { RecipeBookService } from './shared/services/recipe-book/recipe-book.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'LetsEat';

  constructor(private auth: AuthService, private recipeBook: RecipeBookService) {}

  ngOnInit() {
    this.auth.login(
      'josiah.sayers15@gmail.com',
      '91a&eDLmSZG7$az*Iq2mqA9s').subscribe(user => {
        this.getMyRecipes();
      });
  }

  getMyRecipes() {
    this.recipeBook.myRecipes().subscribe(book => console.log(book));
  }
}
