import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecipeBookService } from './services/recipe-book.service';
import { RecipeCardComponent } from './components/recipe-card/recipe-card.component';
import { RecipeBookComponent } from './components/recipe-book/recipe-book.component';
import { RecipeBookRoutingModule } from './recipe-book-routing.module';
import { RecipeComponent } from './components/recipe/recipe.component';
import { ClampyModule } from '@clampy-js/ngx-clampy';

@NgModule({
  declarations: [
    RecipeCardComponent,
    RecipeBookComponent,
    RecipeComponent
  ],
  imports: [
    CommonModule,
    RecipeBookRoutingModule,
    ClampyModule
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
