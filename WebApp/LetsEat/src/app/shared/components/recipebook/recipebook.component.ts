import { Component, OnInit, Input } from '@angular/core';
import { Recipe } from '../../models/recipe.model';

@Component({
  selector: 'app-recipebook',
  templateUrl: './recipebook.component.html',
  styleUrls: ['./recipebook.component.scss']
})
export class RecipebookComponent implements OnInit {

  @Input() recipes: Recipe[];

  constructor() { }

  ngOnInit() {
  }

}
