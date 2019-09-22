import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { RecipeBookComponent } from './components/recipe-book/recipe-book.component';
import { RecipeComponent } from './components/recipe/recipe.component';

const routes: Routes = [
  { path: 'recipe-book/personal', component: RecipeBookComponent },
  { path: 'recipe-book/recipe/:id', component: RecipeComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecipeBookRoutingModule { }