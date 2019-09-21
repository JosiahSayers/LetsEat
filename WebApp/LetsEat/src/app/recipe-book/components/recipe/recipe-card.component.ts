import { Component, Input } from '@angular/core';
import { Recipe } from 'src/app/shared/models/recipe.model';
import { User } from 'src/app/shared/models/user.model';

@Component({
  selector: 'app-recipe-card',
  templateUrl: './recipe-card.component.html',
  styleUrls: ['./recipe-card.component.scss']
})
export class RecipeCardComponent {

  @Input() recipe: Recipe;

  constructor() { }

  get name(): string {
    return this.recipe ? this.recipe.name : '';
  }

  get description(): string {
    return this.recipe ? this.recipe.description : '';
  }

  get user(): User {
    return this.recipe ? this.recipe.userWhoAdded : null;
  }

  get userName(): string {
    return this.user ? this.user.displayName : '';
  }

  get imageUrl(): string {
    return this.recipe ? this.recipe.imageLocations[0] : null;
  }

}
