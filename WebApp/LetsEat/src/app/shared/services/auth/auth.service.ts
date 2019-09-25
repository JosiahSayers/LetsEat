import { Injectable } from '@angular/core';
import { SessionService } from '../session/session.service';
import { HttpService } from '../http/http.service';
import { environment } from 'src/environments/environment';
import { LoginResponse } from '../../models/auth/login-response.model';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { LoginForm } from '../../models/auth/login-form.model';
import { IsEmailAvailableResponse } from '../../models/auth/is-email-available-response.model';
import { CacheService } from '../cache/cache.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private session: SessionService,
    private http: HttpService,
    private cache: CacheService
  ) { }

  login(loginObject: LoginForm): Observable<LoginResponse> {
    return this.http.post({
      url: environment.API.ACCOUNT.LOGIN,
      sendWithAuth: false,
      payload: loginObject
    }).pipe(
      tap(loginResponse => this.cacheLoginResponse(loginResponse))
    ) as any;
  }

  logoff(): Observable<boolean> {
    return this.http.get({
      url: environment.API.ACCOUNT.LOGOFF,
      sendWithAuth: true
    }).pipe(
      tap(() => this.clearLoginFromSession())
    );
  }

  isEmailAvailable(email: string): Observable<IsEmailAvailableResponse> {
    return this.http.get({
      url: environment.API.ACCOUNT.IS_EMAIL_AVAILABLE(email),
      sendWithAuth: false
    });
  }

  private cacheLoginResponse(loginResponse: LoginResponse) {
    this.session.accessToken = loginResponse.accessToken || null;
    this.cache.user = loginResponse.user || null;
  }

  private clearLoginFromSession() {
    this.session.accessToken = null;
    this.cache.user = null;
  }
}
