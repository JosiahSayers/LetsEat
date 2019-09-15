import { HttpHeaders } from '@angular/common/http';

export interface HttpOptions {
  sendWithAuth: boolean;
  url: string;
  payload?: Object;
  headers?: HttpHeaders
}