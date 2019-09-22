import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RecipeBookService } from '../../services/recipe-book.service';
import { Recipe } from 'src/app/shared/models/recipe.model';

@Component({
  selector: 'app-recipe',
  templateUrl: './recipe.component.html',
  styleUrls: ['./recipe.component.scss']
})
export class RecipeComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private recipeBookService: RecipeBookService
  ) { }

  recipe: Recipe;

  ngOnInit() {
    this.route.params.subscribe(params => {
      this.recipe = this.recipeBookService.getRecipe(Number(params.id));
    });
  }

}
