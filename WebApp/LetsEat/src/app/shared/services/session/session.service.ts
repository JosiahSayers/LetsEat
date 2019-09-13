import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SessionService {

  constructor() { }

  set accessToken(token: string) {
    sessionStorage.setItem('accessToken', token);
  }
}
