import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { NavigationService } from '../services/navigation.service';
import { ParentNavbarItem } from '../_interfaces/navigation/parent-navbar-item.model';
import { GetHierarchyNavbarItemsResponse } from '../_interfaces/navigation/navbar-items.response.model';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  isLoggedIn: boolean
  navigationBarItems: ParentNavbarItem[] = []

  constructor(private authService: AuthService,
    private navigationService: NavigationService) {}

  ngOnInit(): void {
    this.isLoggedIn = this.authService.isAuthenticated();

    this.navigationService.getHierarchyNavbarItems()
    .subscribe((response: GetHierarchyNavbarItemsResponse) => {
      this.navigationBarItems = response.items
      console.log(response);
    },
    (err) => console.log(err))
  }
}
