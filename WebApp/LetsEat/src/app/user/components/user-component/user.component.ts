import { Component, OnInit } from '@angular/core';
import { CacheService } from '../../../shared/services/cache/cache.service';
import { Router } from '@angular/router';
import { User } from '../../../shared/models/user.model';
import { AuthService } from 'src/app/shared/services/auth/auth.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  constructor(
    private cache: CacheService,
    private router: Router,
    private auth: AuthService) { }

  ngOnInit() {
    if (!this.isUserLoggedIn) {
      this.router.navigate(['/login']);
    }
  }

  private get isUserLoggedIn(): boolean {
    return this.cache.user !== null && this.cache.user !== undefined;
  }

  get user(): User {
    return this.cache.user;
  }

  get isUserInFamily(): 'Yes' | 'No' {
    return this.user.familyId > 1 ? 'Yes' : 'No';
  }

  logout(): void {
    this.auth.logoff().subscribe();
    this.router.navigate(['/']);
  }
}
