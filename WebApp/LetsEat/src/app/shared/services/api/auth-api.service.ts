import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../../models/Auth/user.model';
import { environment } from 'src/environments/environment';
import { LoggerService } from '../logger.service';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {

  constructor(
    private http: HttpClient,
    private LOGGER: LoggerService
    ) { }

  login(email: string, password: string): Observable<User> {
    return this.http.post<User>(
      environment.LETS_EAT_API.AUTH.LOGIN,
      {
        Email: email,
        Password: password
      }
    );
  }
}
