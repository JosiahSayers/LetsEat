import { Observable } from 'rxjs';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CookieService } from 'ngx-cookie-service';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private cookies: CookieService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if (request.url !== environment.LETS_EAT_API.AUTH.LOGIN) {
      request = request.clone({
        withCredentials: true,
        setHeaders: { Authorization: `Bearer ${this.authToken}` }
      });
    }
  return next.handle(request);
  }

  get authToken(): string {
    return this.cookies.get('.AspNetCore.Session');
  }
}