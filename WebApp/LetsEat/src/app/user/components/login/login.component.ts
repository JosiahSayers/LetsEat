import { Component, OnInit } from '@angular/core';
import { LoginForm } from 'src/app/shared/models/auth/login-form.model';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth/auth.service';
import { catchError } from 'rxjs/operators';
import { of, Observable } from 'rxjs';
import { Router } from '@angular/router';
import { LoginResponse } from '../../../shared/models/auth/login-response.model';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  email: AbstractControl;
  password: AbstractControl;
  loginRequestSent: boolean;

  constructor(
    formBuilder: FormBuilder,
    private auth: AuthService,
    private router: Router
  ) {
    this.loginForm = formBuilder.group({
      'email': ['', [Validators.required, Validators.email]],
      'password': ['', [Validators.required]]
    });

    this.email = this.loginForm.controls['email'];
    this.password = this.loginForm.controls['password'];
  }

  ngOnInit() {
  }

  passwordErrorMessage = "Password error message.";

  onSubmit(formData: LoginForm) {
    this.loginRequestSent = true;
    this.sendLoginRequest(formData);
  }

  private sendLoginRequest(formData: LoginForm) {
    this.auth.login(formData)
    .pipe(
      catchError(() => {
        return this.handleLoginError();
      })
    )
    .subscribe((res: LoginResponse) => {
      this.handleLoginSuccess(res);
    });
  }

  private handleLoginSuccess(res: LoginResponse) {
    this.loginRequestSent = false;
    this.router.navigate(['/user']);
  }

  private handleLoginError(): Observable<any> {
    this.loginRequestSent = false;
    return of(null);
  }
}
