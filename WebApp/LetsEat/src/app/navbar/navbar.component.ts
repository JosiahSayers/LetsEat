import { Component, OnInit } from '@angular/core';
import { NavigationLink } from './navigation-link.model';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(
    private router: Router
  ) { }

  ngOnInit() {
  }

  get navLinks(): NavigationLink[] {
    return environment.NAVBAR_LINKS.AUTHENTICATED;
  }

  navigate(navLink: NavigationLink): void {
    this.router.navigateByUrl(navLink.route);
  }
}
