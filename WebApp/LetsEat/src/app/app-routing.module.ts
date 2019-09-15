import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { FamilyRecipeBookComponent } from './family/family-recipe-book/family-recipe-book.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'family/recipebook', component: FamilyRecipeBookComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
