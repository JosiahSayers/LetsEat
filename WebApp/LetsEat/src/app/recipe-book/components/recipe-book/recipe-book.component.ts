import { Component, OnInit } from '@angular/core';
import { RecipeBookService } from '../../services/recipe-book.service';
import { RecipeBook } from 'src/app/shared/models/recipe-book.model';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';

@Component({
  selector: 'app-recipe-book',
  templateUrl: './recipe-book.component.html',
  styleUrls: ['./recipe-book.component.scss']
})
export class RecipeBookComponent implements OnInit {

  recipeBook: RecipeBook;

  constructor(
    private recipeBookService: RecipeBookService,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    this.route.params.subscribe(params => {
      if (params.type === 'family') {
        this.recipeBookService.getFamilyRecipes()
          .subscribe(recipeBook => this.recipeBook = recipeBook);
      } else {
        this.recipeBookService.getMyRecipes()
          .subscribe(recipeBook => this.recipeBook = recipeBook);
      }
    });
  }

}
