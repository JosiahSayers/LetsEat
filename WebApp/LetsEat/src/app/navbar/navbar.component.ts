import { Component, OnInit } from '@angular/core';
import { NavigationLink } from './navigation-link.model';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  get navLinks(): NavigationLink[] {
    return environment.NAVBAR_LINKS.AUTHENTICATED;
  }
}
