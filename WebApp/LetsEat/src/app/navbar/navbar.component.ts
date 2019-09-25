import { Component, OnInit } from '@angular/core';
import { NavigationLink } from './navigation-link.model';
import { environment } from 'src/environments/environment';
import { User } from '../shared/models/user.model';
import { SessionService } from '../shared/services/session/session.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(private session: SessionService) { }

  ngOnInit() {
  }

  get navLinks(): NavigationLink[] {
    return environment.NAVBAR_LINKS.AUTHENTICATED;
  }

  get user(): User {
    return this.session.user;
  }

  createUserNavLinks(): NavigationLink[] {
    const output = [];

    if (this.user) {
      output.push({
        text: this.user.displayName,
        route: '/user'
      });
    }

    if (this.user.isAdmin) {
      output.push({
        text: 'Admin',
        route: '/admin'
      });
    }

    return output;
  }
}
