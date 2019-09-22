import { Component, OnInit } from '@angular/core';
import { RecipeBookService } from '../../services/recipe-book.service';
import { RecipeBook } from 'src/app/shared/models/recipe-book.model';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { Title } from '@angular/platform-browser';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-recipe-book',
  templateUrl: './recipe-book.component.html',
  styleUrls: ['./recipe-book.component.scss']
})
export class RecipeBookComponent implements OnInit {

  recipeBook: RecipeBook;

  constructor(
    private recipeBookService: RecipeBookService,
    private route: ActivatedRoute,
    private title: Title
    ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (params.type === 'family') {
        this.title.setTitle(environment.PAGE_TITLES.RECIPE_BOOK.FAMILY);
        this.recipeBookService.getFamilyRecipes()
          .subscribe(recipeBook => this.recipeBook = recipeBook);
      } else {
        this.title.setTitle(environment.PAGE_TITLES.RECIPE_BOOK.PERSONAL);
        this.recipeBookService.getMyRecipes()
          .subscribe(recipeBook => this.recipeBook = recipeBook);
      }
    });
  }

}
