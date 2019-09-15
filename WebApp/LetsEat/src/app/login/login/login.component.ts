import { Component, OnInit } from '@angular/core';
import { LoginForm } from 'src/app/shared/models/login-form.model';
import { FormGroup, FormBuilder, Validators, AbstractControl } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginForm: FormGroup;
  email: AbstractControl;
  password: AbstractControl;

  constructor(
    formBuilder: FormBuilder,
    private auth: AuthService
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
    this.auth.login(formData).subscribe(response => console.log(response));
  }
}
