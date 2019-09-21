import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecipeBookService } from './services/recipe-book.service';
import { RecipeCardComponent } from './components/recipe/recipe-card.component';
import { RecipeBookComponent } from './components/recipe-book/recipe-book.component';
import { RecipeBookRoutingModule } from './recipe-book-routing.module';

@NgModule({
  declarations: [
    RecipeCardComponent,
    RecipeBookComponent
  ],
  imports: [
    CommonModule,
    RecipeBookRoutingModule
  ],
  providers: [
    RecipeBookService
  ],
  exports: [
    RecipeBookComponent,
    CommonModule,
    RecipeCardComponent,
    RecipeBookRoutingModule
  ]
})
export class RecipeBookModule { }
