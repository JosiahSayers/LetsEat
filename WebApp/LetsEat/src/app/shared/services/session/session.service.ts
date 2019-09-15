import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor() { }

  get accessToken() {
    return sessionStorage.getItem(environment.SESSION_KEYS.ACCESS_TOKEN);
  }

  set accessToken(token: string) {
    sessionStorage.setItem(environment.SESSION_KEYS.ACCESS_TOKEN, token);
  }

  get user(): User {
    return JSON.parse(sessionStorage.getItem(environment.SESSION_KEYS.USER));
  }

  set user(user: User) {
    sessionStorage.setItem(environment.SESSION_KEYS.USER, JSON.stringify(user));
  }
}
