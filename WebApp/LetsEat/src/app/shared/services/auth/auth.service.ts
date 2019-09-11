import { Injectable } from '@angular/core';
import { AuthApiService } from '../api/auth-api.service';
import { SessionService } from '../session.service';
import { User } from '../../models/Auth/user.model';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private api: AuthApiService,
    private sessionService: SessionService
  ) { }

  get currentUser(): User {
    return this.sessionService.user;
  }

  login(email: string, password: string): Observable<User> {
    return this.api.login(email, password).pipe(
      tap(user => this.sessionService.user = user)
    );
  }
}
