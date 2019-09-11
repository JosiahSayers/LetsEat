import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './shared/services/api/auth-interceptor';
import { LoggerService } from './shared/services/logger.service';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthApiService } from './shared/services/api/auth-api.service';
import { AuthService } from './shared/services/auth/auth.service';
import { RecipeBookService } from './shared/services/recipe-book/recipe-book.service';
import { CookieService } from 'ngx-cookie-service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [
    LoggerService,
    AuthApiService,
    AuthService,
    RecipeBookService,
    CookieService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true,
      }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
