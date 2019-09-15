import { Injectable } from '@angular/core';
import { SessionService } from '../session/session.service';
import { HttpService } from '../http/http.service';
import { environment } from 'src/environments/environment';
import { LoginResponse } from '../../models/login-response.model';
import { tap } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { LoginForm } from '../../models/login-form.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(
    private session: SessionService,
    private http: HttpService
  ) { }

  public login(loginObject: LoginForm): Observable<LoginResponse> {
    return this.http.post({
      url: environment.API.ACCOUNT.LOGIN,
      sendWithAuth: false,
      payload: loginObject
    }).pipe(
      tap(loginResponse => this.storeLoginResponseToSession(loginResponse))
    ) as any;
  }

  public logoff(): Observable<boolean> {
    return this.http.get({
      url: environment.API.ACCOUNT.LOGOFF,
      sendWithAuth: true
    }).pipe(
      tap(logOffResponse => this.clearLoginFromSession())
    );
  }

  private storeLoginResponseToSession(loginResponse: LoginResponse) {
    this.session.accessToken = loginResponse.accessToken || null;
    this.session.user = loginResponse.user || null;
  }

  private clearLoginFromSession() {
    this.session.accessToken = null;
    this.session.user = null;
  }
}
