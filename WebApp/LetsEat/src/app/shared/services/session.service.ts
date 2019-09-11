import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../models/Auth/user.model';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor(private cookies: CookieService) { }

  get user(): User {
    return JSON.parse(sessionStorage.getItem(environment.SESSION_KEYS.USER));
  }

  set user(user: User) {
    sessionStorage.setItem(
      environment.SESSION_KEYS.USER,
      JSON.stringify(user)
    );
  }

  get apiSessionKey(): string {
    return this.cookies.get(environment.SESSION_KEYS.API_SESSION_KEY);
  }
}
