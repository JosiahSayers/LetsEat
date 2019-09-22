import { Component, OnInit } from '@angular/core';
import { User } from './shared/models/user.model';
import { initializeNavBar } from './navbar/navbar-initialize.js';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {  
  title = 'Lets Eat!';
  canLoadApplication = false;
  user: User;

  constructor() { }

  ngOnInit() {
    initializeNavBar();
  }
}
