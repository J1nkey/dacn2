import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ParentNavbarItem } from '../_interfaces/navigation/parent-navbar-item.model';
import { Observable } from 'rxjs';
import { GetHierarchyNavbarItemsResponse } from '../_interfaces/navigation/navbar-items.response.model';

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  private baseApiUrl: string = "https://localhost:7228/api/navigation";
  constructor(private client: HttpClient) { }

  getHierarchyNavbarItems(): Observable<GetHierarchyNavbarItemsResponse> {
    var data = this.client.get<GetHierarchyNavbarItemsResponse>(this.baseApiUrl + "/GetHierarchyNavbarItems")
    return data;
  }
}
