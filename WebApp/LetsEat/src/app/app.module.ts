import { BrowserModule, Title } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthService } from './shared/services/auth/auth.service';
import { SessionService } from './shared/services/session/session.service';
import { HttpService } from './shared/services/http/http.service';
import { HttpClientModule } from '@angular/common/http';
import { RecipeBookService } from './recipe-book/services/recipe-book.service';
import { LoginComponent } from './user/components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './user/components/register/register.component';
import { RecipeBookModule } from './recipe-book/recipe-book.module';
import { RecipeBookRoutingModule } from './recipe-book/recipe-book-routing.module';
import { NavbarComponent } from './navbar/navbar.component';
import { ClampyModule } from '@clampy-js/ngx-clampy';
import { CacheService } from './shared/services/cache/cache.service';
import { UserComponent } from './user/components/user-component/user.component';
import { UserModule } from './user/user.module';
import { UserRoutingModule } from './user/user-routing.module';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    NavbarComponent,
    UserComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RecipeBookRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RecipeBookModule,
    ClampyModule,
    UserModule,
    UserRoutingModule
  ],
  providers: [
    AuthService,
    SessionService,
    HttpService,
    RecipeBookService,
    Title,
    CacheService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
