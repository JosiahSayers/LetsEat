import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoggerService {

  log(message: any) {
    if (!environment.production) {
      console.log(message);
    }
  }

  error(message: any) {
    if (!environment.production) {
      console.error(message);
    }
  }
}
