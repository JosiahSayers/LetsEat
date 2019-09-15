import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    this.subscribeToEmailChanges();
  }

  subscribeToEmailChanges() {
    // this.email.valueChanges.subscribe(text => {
    //   if (this.email.valid) {
    //     const email = this.email.value;
    //     setTimeout(() => {
    //       if (email === this.email.value) {
    //         this.callIsEmailIsAvailableEndpoint();
    //       }
    //     }, 750)
    //   }
    // });
  }

  callIsEmailIsAvailableEndpoint() {
    // this.auth.isEmailAvailable(this.email.value).subscribe(res => {
    //   if (res.email === this.email.value) {
    //     this.isEmailAvailable = res.isAvailable;
    //   } else {
    //     this.isEmailAvailable = null;
    //   }
    // });
  }

}
