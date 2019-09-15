import { Injectable } from '@angular/core';
import { SessionService } from '../session/session.service';
import { HttpOptions } from './http-options.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(
    private session: SessionService,
    private httpClient: HttpClient
  ) { }

  public post(options: HttpOptions): Observable<any> {
    const headers = this.createHeaders(options);

    return this.httpClient.post(
      options.url,
      options.payload,
      {
        headers
      }
    );
  }

  public get(options: HttpOptions): Observable<any> {
    const headers = this.createHeaders(options);

    return this.httpClient.get(
      options.url,
      {
        headers
      }
    )
  }

  private createHeaders(options: HttpOptions): HttpHeaders {
    let headers: HttpHeaders;

    if (options.sendWithAuth) {
      headers = this.createHeadersWithAuth(options.headers);
    } else {
      headers = options.headers || new HttpHeaders();
    }

    headers = headers.append('Content-Type', 'application/json');

    return headers;
  }

  private createHeadersWithAuth(headersFromOptions: HttpHeaders): HttpHeaders {
    let headers = headersFromOptions || new HttpHeaders();
    headers = headers.append('Authorization', this.session.accessToken);
    
    return headers;
  }
}
