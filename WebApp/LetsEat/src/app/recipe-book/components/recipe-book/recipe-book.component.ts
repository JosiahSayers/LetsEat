import { Component, OnInit, Input } from '@angular/core';
import { RecipeBookService } from '../../services/recipe-book.service';
import { RecipeBook } from 'src/app/shared/models/recipe-book.model';

@Component({
  selector: 'app-recipe-book',
  templateUrl: './recipe-book.component.html',
  styleUrls: ['./recipe-book.component.scss']
})
export class RecipeBookComponent implements OnInit {

  @Input() recipeBook: RecipeBook;

  constructor(private recipeBookService: RecipeBookService) { }

  ngOnInit() {
    this.recipeBookService.getMyRecipes().subscribe(recipeBook => this.recipeBook = recipeBook);
  }

}
