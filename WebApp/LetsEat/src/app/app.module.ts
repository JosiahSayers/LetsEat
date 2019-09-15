import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthService } from './shared/services/auth/auth.service';
import { SessionService } from './shared/services/session/session.service';
import { HttpService } from './shared/services/http/http.service';
import { HttpClientModule } from '@angular/common/http';
import { RecipeBookService } from './recipe-book/services/recipe-book.service';
import { LoginComponent } from './login/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    AuthService,
    SessionService,
    HttpService,
    RecipeBookService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
